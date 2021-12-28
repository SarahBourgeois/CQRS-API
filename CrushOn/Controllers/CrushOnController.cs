using System.Net;
using CrushOn.Infrastructure.Abstract.Response;
using Microsoft.AspNetCore.Mvc;

namespace CrushOn.API.Controllers
{
    public class CrushOnController : ControllerBase
    {
        protected IActionResult HandleErrorResponse<T>(IServiceResponse<T> response) =>
            new ObjectResult(response) { StatusCode = (int)(response.HttpCode ?? HttpStatusCode.ServiceUnavailable) };

        protected IActionResult HandleErrorResponse<T>(T response, HttpStatusCode? statusCode)
        {
            var status = statusCode ?? HttpStatusCode.ServiceUnavailable;
            status = status == HttpStatusCode.ServiceUnavailable ? HttpStatusCode.ServiceUnavailable : status;
            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
    }
}