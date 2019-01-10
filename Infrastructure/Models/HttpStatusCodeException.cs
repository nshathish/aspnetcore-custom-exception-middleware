namespace aspnetcore_custom_exception_middleware.Infrastructure.Models
{
    using System;
    using System.Net;
    using Newtonsoft.Json;

    public class HttpStatusCodeException: Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
