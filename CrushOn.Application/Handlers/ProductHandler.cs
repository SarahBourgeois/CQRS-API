using System;
using System.Threading;
using System.Threading.Tasks;
using CrushOn.Application.Commands;
using CrushOn.Application.Reponses;
using CrushOn.Core.EntitiesModel;
using CrushOn.Core.Repositories;
using MediatR;

public class ProductHandler : IRequestHandler<ProductCommand, ProductResponse>
{
    private readonly IProductRepository _productRepository;
    private CrushOnContext _context;


    public ProductHandler(IProductRepository productRepository, CrushOnContext context)
    {
        _productRepository = productRepository;
        _context = context;
    }

    public async Task<ProductResponse> Handle(ProductHandler request, CancellationToken cancellationToken)
    {
        var productEntity = CrushOnMapper.Mapper.Map<ProductModel>(request);
        if (productEntity is null)
        {
            throw new ApplicationException("Issue with mapper");
        }

        var product = await _productRepository.AddAsync(productEntity);

        ProductResponse response = CrushOnMapper.Mapper.Map<ProductResponse>(product);

        return response;
    }

    async Task<ProductResponse> IRequestHandler<ProductCommand, ProductResponse>.Handle(ProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = CrushOnMapper.Mapper.Map<ProductModel>(request);

        if (productEntity is null)
        {
            throw new ApplicationException("Issue with mapper");
        }

        using Task<ProductModel> newProduct = _productRepository.AddAsync(productEntity);
        ProductResponse response = new ProductResponse
        {
            Title = newProduct.Result.Title,
            Price = newProduct.Result.Price,
            Stock = newProduct.Result.Stock,
        };

        return response;
    }

}
