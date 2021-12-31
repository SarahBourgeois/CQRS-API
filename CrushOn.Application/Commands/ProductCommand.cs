using CrushOn.Application.Reponses;
using MediatR;

namespace CrushOn.Application.Commands
{
    public class ProductCommand : IRequest<ProductResponse>
    {
        public string Title { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
    }
}
