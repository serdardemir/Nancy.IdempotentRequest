using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.IdempotentRequest
{
    public sealed class RequestOptions
    {
        static readonly RequestOptions _instance = new RequestOptions();
        private string idempotencyKey;
        public static RequestOptions Instance
        {
            get
            {
                return _instance;
            }
        }
        RequestOptions()
        {
            // Initialize.
        }

        public RequestOptions SetIdempotencyKey(string idempotencyKey)
        {
            this.idempotencyKey = idempotencyKey;
            return this;
        }

        public string GetIdempotencyKey()
        {
            return this.idempotencyKey;
        }


    }

}
