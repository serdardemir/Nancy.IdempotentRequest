using System;
using System.Linq;

namespace Nancy.IdempotentRequest.Test
{
    public interface IDummyApiClient
    {
        T Post<T>(T message);

        void Post(DummyMessage message);
    }
}
