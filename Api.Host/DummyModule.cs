using Nancy;
using System;
using System.Collections.Generic;
using Nancy.ModelBinding;
using System.Linq;
using System.Web;
using Nancy.IdempotentRequest.Extensions;
<<<<<<< HEAD
=======
using Nancy.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
>>>>>>> origin/master

namespace Api.Host
{
    public class DummyModule : NancyModule
    {
<<<<<<< HEAD
        public DummyModule() : base("api")
=======
        public DummyModule()
        //: base("api")
>>>>>>> origin/master
        {
            {
                
                Post["/createLog"] = p =>
                {
<<<<<<< HEAD
                    this.Context.EnableOutputCache(10);
                    //business logic here...
                    return HttpStatusCode.OK;
                };

                Put["/updateLog"] = p =>
                {
                    this.Context.EnableOutputCache(10);
                    //business logic here...
                    return HttpStatusCode.OK;
=======
                    this.Context.EnableOutputCache(300);
                    
                    dynamic request = JsonConvert.DeserializeObject(Request.Body.AsString());

                    var blog = new Blog
                    {
                        blogId = request.Value<int>("blogId"),
                        title = request.Value<string>("title"),
                        addedDate = request.Value<DateTime>("addedDate"),
                        tag = request.Value<string>("tag"),
                    };

                    return null;
>>>>>>> origin/master
                };

                Get["/"] = p =>
                {
<<<<<<< HEAD
                    this.Context.EnableOutputCache(10);
                    return HttpStatusCode.OK;
                };
                Get["/{0}"] = p =>
                {
                    this.Context.EnableOutputCache(10);
                    return HttpStatusCode.OK;
=======
                    return "";
>>>>>>> origin/master
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