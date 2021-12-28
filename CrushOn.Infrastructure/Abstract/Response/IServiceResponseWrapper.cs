using System.Net;

namespace CrushOn.Infrastructure.Abstract.Response
{
    public interface IServiceResponseWrapper
    {
        IServiceResponse<object> Wrap(object response, bool found, bool isValid);
        IServiceResponse<To> Wrap<To>(To response, bool found, bool isValid, HttpStatusCode? httpCode = null,
            string errorCode = null, string errorMessage = null);
    }
}