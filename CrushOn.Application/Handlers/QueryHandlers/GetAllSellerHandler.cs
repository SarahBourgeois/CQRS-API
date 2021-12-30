using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CrushOn.Application.Queries;
using CrushOn.Core.EntitiesModel;
using MediatR;

namespace CrushOn.Application.Handlers.QueryHandlers
{
    public class GetAllSellerHandler  : IRequestHandler<GetAllSellers, List<SellerModel>>
    {
        private readonly ISellerRepository _sellerRepository;

    public GetAllSellerHandler(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task<List<SellerModel>> Handle(GetAllSellers request, CancellationToken cancellationToken)
    {
        return (List<SellerModel>)await _sellerRepository.GetAllAsync();
    }
}
}
