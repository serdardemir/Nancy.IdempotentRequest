using System;
using System.Linq;

namespace Nancy.IdempotentRequest.Test
{
    public class ApiClient : IApiClient
    {
        public string apiAddress { get; set; }

        public ApiClient(string apiAddress)
        {
            this.apiAddress = apiAddress;
        }

        public T Post<T>(T message)
        {
            return default(T);
        }
    }
}