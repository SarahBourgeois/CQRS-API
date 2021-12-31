using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrushOn.Core.EntitiesModel;
using CrushOn.Core.Repositories;
using Microsoft.EntityFrameworkCore;

public class ProductRepository : Repository<ProductModel>, IProductRepository
{
    public ProductRepository(CrushOnContext crushOnContext) : base(crushOnContext) { }

    public async Task<IEnumerable<ProductModel>> GetAllProducts()
    {
        return await _crushOnContext.Products.ToListAsync();
    }
}