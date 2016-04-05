using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.IdempotentRequest.Test
{
    public class DummyMessage
    {
        int id;
        string title;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        string body;

        public string Body
        {
            get
            {
                return body;
            }
            set
            {
                body = value;
            }
        }

        string tag;

        public string Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}