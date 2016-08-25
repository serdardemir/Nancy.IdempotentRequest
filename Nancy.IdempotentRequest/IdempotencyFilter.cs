using System;
using System.Globalization;
using System.Linq;
using Nancy.IdempotentRequest.Helper;

namespace Nancy.IdempotentRequest
{
    public static class IdempotencyFilter
    {
        public static void RegisterCacheCheck(this NancyModule nancyModule)
        {
            nancyModule.After.AddItemToEndOfPipeline(CheckForCached);
        }

        static void CheckForCached(NancyContext context)
        {
            var responseHeaders = context.Response.Headers;
            var requestHeaders = context.Request.Headers;

            var etag = EntityFilterHelper.GenerateETag(context.Request.Body);
            responseHeaders.Add("ETag", etag);

            string currentFileEtag;
            if (responseHeaders.TryGetValue("ETag", out currentFileEtag))
            {
                if (requestHeaders.IfNoneMatch.Contains(currentFileEtag))
                {
                    context.Response = HttpStatusCode.NotModified;
                    return;
                }
            }

            string responseLastModifiedString;
            if (responseHeaders.TryGetValue("Last-Modified", out responseLastModifiedString))
            {
                var responseLastModified = DateTime.ParseExact(responseLastModifiedString, "R", CultureInfo.InvariantCulture, DateTimeStyles.None);
                if (responseLastModified <= requestHeaders.IfModifiedSince)
                {
                    context.Response = HttpStatusCode.NotModified;
                }
            }
        }
    }
}