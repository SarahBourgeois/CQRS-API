using System;
using System.Threading;
using System.Threading.Tasks;
using CrushOn.Application.Commands;
using CrushOn.Application.Reponses;
using CrushOn.Core.EntitiesModel;
using MediatR;

public class SellerHandler : IRequestHandler<SellerCommand, SellerResponse>
{
    private readonly ISellerRepository _sellerRepository;
    private CrushOnContext _context;
    

    public SellerHandler(ISellerRepository sellerRepository, CrushOnContext context)
    {
        _sellerRepository = sellerRepository;
        _context = context;
    }

    public async Task<SellerResponse> Handle(SellerHandler request, CancellationToken cancellationToken)
    {
        var sellerEntity = CrushOnMapper.Mapper.Map<SellerModel>(request);
        if (sellerEntity is null)
        {
            throw new ApplicationException("Issue with mapper");
        }

        var seller = await _sellerRepository.AddAsync(sellerEntity);
        SellerResponse sellerResponse = CrushOnMapper.Mapper.Map<SellerResponse>(seller);

        return sellerResponse;
    }

    async Task<SellerResponse> IRequestHandler<SellerCommand, SellerResponse>.Handle(SellerCommand request, CancellationToken cancellationToken)
    {
        var sellerEntity = CrushOnMapper.Mapper.Map<SellerModel>(request);

        if (sellerEntity is null)
        {
            throw new ApplicationException("Issue with mapper");
        }

        using Task<SellerModel> newSeller = _sellerRepository.AddAsync(sellerEntity);
        SellerResponse sellerResponse = new SellerResponse
        {
            Email = newSeller.Result.Email,
            StoreName = newSeller.Result.StoreName
        };

        return sellerResponse;
    }

}
