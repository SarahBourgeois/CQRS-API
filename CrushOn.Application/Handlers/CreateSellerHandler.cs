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
        var employeeEntitiy = SellerMapper.Mapper.Map<SellerModel>(request);
        if (employeeEntitiy is null)
        {
            throw new ApplicationException("Issue with mapper");
        }
        var newEmployee = await _sellerRepository.AddAsync(employeeEntitiy);
        var employeeResponse = SellerMapper.Mapper.Map<SellerResponse>(newEmployee);
        return employeeResponse;
    }
}
