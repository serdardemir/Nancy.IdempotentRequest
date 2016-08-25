using System;
using System.Linq;
using RestSharp;

namespace Nancy.IdempotentRequest.Test
{
    public class DummyApiClient : IDummyApiClient
    {
        public string ApiAddress = "http://localhost/Api.Host.Nancy/api/createLog";

        public T Post<T>(T message)
        {
            return default(T);
        }

        public void Post(DummyMessage message)
        {
            RestRequest request;
            var client = PrepareRestClientWithRequestBody(message, out request);
            client.Post(request);
        }

        private RestClient PrepareRestClientWithRequestBody(object requestBody, out RestRequest request)
        {
            var client = new RestClient(ApiAddress);

            request = new RestRequest { RequestFormat = DataFormat.Json };            
            request.AddBody(requestBody);
            return client;
        }
    }
}