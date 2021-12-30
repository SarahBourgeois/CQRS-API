using System;
using System.Threading;
using System.Threading.Tasks;
using CrushOn.Application.Commands;
using CrushOn.Application.Reponses;
using CrushOn.Core.Entities;
using MediatR;

public class CreateSellerHandler : IRequestHandler<CreateSellerCommand, SellerResponse>
{
    private readonly ISellerRepository _sellerRepository;

    public CreateSellerHandler(ISellerRepository employeeRepository)
    {
        _sellerRepository = employeeRepository;
    }

    public async Task<SellerResponse> Handle(CreateSellerHandler request, CancellationToken cancellationToken)
    {
        var sellerEntity = SellerMapper.Mapper.Map<SellerModel>(request);
        if (sellerEntity is null)
        {
            throw new ApplicationException("Issue with mapper");
        }
        var seller = await _sellerRepository.AddAsync(sellerEntity);
        var sellerResponse = SellerMapper.Mapper.Map<SellerResponse>(seller);

        return sellerResponse;
    }

    public Task<SellerResponse> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
    {
        var sellerEntity = SellerMapper.Mapper.Map<SellerModel>(request);

        if (sellerEntity is null)
        {
            throw new ApplicationException("Issue with mapper");
        }

        Task<SellerModel> newSeller =  _sellerRepository.AddAsync(sellerEntity);

        SellerResponse sellerResponse = SellerMapper.Mapper.Map<SellerResponse>(newSeller);

        return null;
    }
}
