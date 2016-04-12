using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.IdempotentRequest
{
    public class CachedResponse : Response
    {
        private readonly string oldResponseOutput;

        public CachedResponse(Response response)
        {
            this.ContentType = response.ContentType;
            this.Headers = response.Headers;
            this.StatusCode = response.StatusCode;

            using (var memoryStream = new MemoryStream())
            {
                response.Contents.Invoke(memoryStream);
                this.oldResponseOutput = Encoding.ASCII.GetString(memoryStream.GetBuffer());
            }

            this.Contents = GetContents(this.oldResponseOutput);
        }

        protected static Action<Stream> GetContents(string contents)
        {
            return stream =>
            {
                var writer = new StreamWriter(stream) { AutoFlush = true };
                writer.Write(contents);
            };
        }
    }
}