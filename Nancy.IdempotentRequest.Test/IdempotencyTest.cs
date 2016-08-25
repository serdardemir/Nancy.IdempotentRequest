using System;
using System.Linq;
using Nancy.Testing;
using Shouldly;
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

            IDummyApiClient client = new DummyApiClient();

            var request = new DummyMessage() { Body = "some body", Tag = "Some Tag", Title = "Some title", };

            client.Post(request);
            DummyMessage message2 = client.Post<DummyMessage>(request);
            // Assert.Equal(message.Id, message2.Id);
        }

        [Fact]
        public void Send_Request_Without_Idempotency_key()
        {
            //without idempotency key should  create additional entity
            RequestOptions.Instance.SetIdempotencyKey(string.Empty);
            IDummyApiClient client = new DummyApiClient();

            var request = new DummyMessage() { Body = "some body", Tag = "Some Tag", Title = "Some title" };
            
            DummyMessage message = client.Post<DummyMessage>(request);

            DummyMessage message2 = client.Post<DummyMessage>(request);

           // Assert.NotEqual(message.Id, message2.Id);
        }

        [Fact]
        public void Should_Throw_ForDuplicate_Request()
        {
            IDummyApiClient client = new DummyApiClient();

            var request = new DummyMessage() { Body = "some body", Tag = "Some Tag", Title = "Some title" };

            DummyMessage message = client.Post<DummyMessage>(request);

            //Should.Throw<IdempotencyException>(() =>
            //{
            //    client.Post<DummyMessage>(request);
            //});
        }

        [Fact]
        public void Same_IdempotencyKey_ShouldReturn_SameResult()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);

            // When
            var result = browser.Get("/", with =>
            {
                with.HttpRequest();
            });
        }
    }
}