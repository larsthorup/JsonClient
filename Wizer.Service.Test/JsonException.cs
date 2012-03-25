using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Wizer.Service.Test
{
    public class JsonException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public dynamic Result { get; private set; }

        public JsonException(WebException ex, dynamic result)
            : base(ex.Message, ex)
        {
            var response = ex.Response as HttpWebResponse;
            StatusCode = response.StatusCode;
            Result = result;
        }
    }
}
