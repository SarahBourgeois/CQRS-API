using System.Net;

namespace CrushOn.Infrastructure.Abstract.Response
{
    public interface IServiceResponse<TContent> 
    {
        TContent Document { get; set; }
        string ErrorCode { get; set; }
        string ErrorMessage { get; set; }
        string AccessToken { get; set; }
        HttpStatusCode? HttpCode { get; set; }
    }
    public interface IServiceResponse 
    {
        string ErrorCode { get; set; }
        string ErrorMessage { get; set; }
        HttpStatusCode? HttpCode { get; set; }
    }
}