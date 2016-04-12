using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Host
{
    public class DummyModule : NancyModule
    {
        public DummyModule()
        {
            {
                Put["/updateBlog"] = p =>
                {
                    //this.Context.EnableOutputCache(30);


                    //Blog blog = this.Bind<Blog>();
                    //BlogFixture.Blogs.Add(blog);
                    //return BlogFixture.Blogs.Count;
                    return null;
                };

            }
        }
    }
}