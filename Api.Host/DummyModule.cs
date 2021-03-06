﻿using System;
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
    }
}