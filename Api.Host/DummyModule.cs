using System;
using System.Linq;
using Nancy;
using Nancy.IdempotentRequest.Extensions;

namespace Api.Host
{
    public class DummyModule : NancyModule
    {
        public DummyModule() : base("api")

        {
            {
                Post["/createLog"] = p =>
                {
                    this.Context.EnableOutputCache(10);
                    //business logic here...
                    return HttpStatusCode.OK;
                };

                Put["/updateLog"] = p =>
                {
                    this.Context.EnableOutputCache(10);
                    //business logic here...
                    return HttpStatusCode.OK;
                };

                Get["/"] = p =>
                {
                    this.Context.EnableOutputCache(10);
                    return HttpStatusCode.OK;
                };
                Get["/{0}"] = p =>
                {
                    this.Context.EnableOutputCache(10);
                    return HttpStatusCode.OK;
                };
            }
        }

        public class Blog
        {
            public int blogId { get; set; }

            public string title { get; set; }

            public string body { get; set; }

            public string tag { get; set; }

            public DateTime addedDate { get; set; }
        }
    }
}