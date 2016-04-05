using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Nancy.IdempotentRequest.Test
{
    public class IdempotencyTest
    {
        [Fact]
        public void Send_Request_With_Idempotency_key()
        {
            var idempotencyKey = Guid.NewGuid().ToString();

            //with idempotency key should not create additional entity
            RequestOptions.Instance.SetIdempotencyKey(idempotencyKey);
            IApiClient client = new ApiClient("http://localhost:57918/");

            var request = new DummyMessage() { Body = "some body", Tag = "Some Tag", Title = "Some title" };

            
            DummyMessage message = client.Post<DummyMessage>(request);
            DummyMessage message2 = client.Post<DummyMessage>(request);

            Assert.Equal(message.Id, message2.Id);

        }

        [Fact]
        public void Send_Request_Without_Idempotency_key()
        {
            //without idempotency key should  create additional entity
            RequestOptions.Instance.SetIdempotencyKey(string.Empty);
            IApiClient client = new ApiClient("http://localhost:57918/");

            var request = new DummyMessage() { Body = "some body", Tag = "Some Tag", Title = "Some title" };

            
            DummyMessage message = client.Post<DummyMessage>(request);

            DummyMessage message2 = client.Post<DummyMessage>(request);

            Assert.NotEqual(message.Id, message2.Id);

        }
    }
}
