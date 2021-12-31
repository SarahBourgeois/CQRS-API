using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CrushOn.Application.Queries;
using CrushOn.Core.EntitiesModel;
using CrushOn.Core.Repositories;
using MediatR;

namespace CrushOn.Application.Handlers.QueryHandlers
{
    public class GetAllProductHandler : IRequestHandler<GetAllProducts, List<ProductModel>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductModel>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            return (List<ProductModel>)await _productRepository.GetAllAsync();
        }
    }
}
