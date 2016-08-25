using System;
using System.Collections.Generic;
using System.Linq;
using Nancy.Bootstrapper;
using Nancy.IdempotentRequest.Extensions;
using Nancy.TinyIoc;

namespace Nancy.IdempotentRequest
{
    public class CachingBootstrapper : DefaultNancyBootstrapper
    {
        private const int CACHE_SECONDS = 30;

        private readonly Dictionary<string, Tuple<DateTime, Response, int>> cachedResponses = new Dictionary<string, Tuple<DateTime, Response, int>>();

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            pipelines.BeforeRequest += CheckCache;

            pipelines.AfterRequest += SetCache;
        }

        public Response CheckCache(NancyContext context)
        {
            Tuple<DateTime, Response, int> cacheEntry;

            if (this.cachedResponses.TryGetValue(context.Request.Path, out cacheEntry))
            
                if (cacheEntry.Item1.AddSeconds(cacheEntry.Item3) > DateTime.Now)
                
                    return cacheEntry.Item2;
            
            return null;
        }

        public void SetCache(NancyContext context)
        {
            if (context.Response.StatusCode != HttpStatusCode.OK)            
                return;

            object cacheSecondsObject;
            if (!context.Items.TryGetValue(ContextExtensions.OUTPUT_CACHE_TIME_KEY, out cacheSecondsObject))            
                return;

            int cacheSeconds;
            if (!int.TryParse(cacheSecondsObject.ToString(), out cacheSeconds))                
                return;

            var cachedResponse = new CachedResponse(context.Response);

            this.cachedResponses[context.Request.Path] = new Tuple<DateTime, Response, int>(DateTime.Now, cachedResponse, cacheSeconds);

            context.Response = cachedResponse;
        }
    }
}