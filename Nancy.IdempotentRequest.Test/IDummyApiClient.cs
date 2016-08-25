using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.IdempotentRequest.Test
{
    public interface IDummyApiClient
    {
        T Post<T>(T message);

        void Post(DummyMessage message);
    }
}
