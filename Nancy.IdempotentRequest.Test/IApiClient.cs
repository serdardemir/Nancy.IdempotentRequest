using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.IdempotentRequest.Test
{
    public interface IApiClient
    {
        T Post<T>(T message);
    }
}
