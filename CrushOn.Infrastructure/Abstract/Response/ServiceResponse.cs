using System;
using System.Net;

namespace CrushOn.Infrastructure.Abstract.Response
{
    public class ServiceResponse<TContent> : IServiceResponse<TContent>
    {
        public string DebugInformation { get; set; }
        public TContent Document { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string AccessToken { get; set; }
        public bool Found { get; set; }
        public HttpStatusCode? HttpCode { get; set; }
        public bool IsValid { get; set; }
        public Exception OriginalException { get; set; }
    }

    public class ServiceResponse : IServiceResponse
    {
        public string DebugInformation { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool Found { get; set; }
        public HttpStatusCode? HttpCode { get; set; }
        public bool IsValid { get; set; }
        public Exception OriginalException { get; set; }
    }
}