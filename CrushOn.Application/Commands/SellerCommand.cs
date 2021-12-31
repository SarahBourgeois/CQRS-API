using CrushOn.Application.Reponses;
using MediatR;

namespace CrushOn.Application.Commands
{
    public class SellerCommand : IRequest<SellerResponse>
    {
        public string StoreName { get; set; }
        public string Email { get; set; }
    }
}
