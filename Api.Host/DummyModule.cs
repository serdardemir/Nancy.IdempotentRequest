using Nancy;
using System;
using System.Collections.Generic;
using Nancy.ModelBinding;
using System.Linq;
using System.Web;
using Nancy.IdempotentRequest.Extensions;
using Nancy.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Api.Host
{
    public class DummyModule : NancyModule
    {
        public DummyModule()
        //: base("api")
        {
            {
                Put["/updateBlog"] = p =>
                {
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
                };

                Get["/"] = p =>
                {
                    return "";
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