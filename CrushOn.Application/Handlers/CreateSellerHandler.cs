using System;
using System.Threading;
using System.Threading.Tasks;
using CrushOn.Application.Commands;
using CrushOn.Application.Reponses;
using CrushOn.Core.EntitiesModel;
using MediatR;

public class CreateSellerHandler : IRequestHandler<CreateSellerCommand, SellerResponse>
{
    private readonly ISellerRepository _sellerRepository;
    private CrushOnContext _context;
    

    public CreateSellerHandler(ISellerRepository sellerRepository, CrushOnContext context)
    {
        _sellerRepository = sellerRepository;
        _context = context;
    }

    public async Task<SellerResponse> Handle(CreateSellerHandler request, CancellationToken cancellationToken)
    {
        var sellerEntity = SellerMapper.Mapper.Map<SellerModel>(request);
        if (sellerEntity is null)
        {
            throw new ApplicationException("Issue with mapper");
        }

        var seller = await _sellerRepository.AddAsync(sellerEntity);
        SellerResponse sellerResponse = SellerMapper.Mapper.Map<SellerResponse>(seller);

        return sellerResponse;
    }

    async Task<SellerResponse> IRequestHandler<CreateSellerCommand, SellerResponse>.Handle(CreateSellerCommand request, CancellationToken cancellationToken)
    {
        var sellerEntity = SellerMapper.Mapper.Map<SellerModel>(request);

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
