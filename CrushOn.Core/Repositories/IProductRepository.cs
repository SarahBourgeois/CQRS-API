using System.Collections.Generic;
using System.Threading.Tasks;
using CrushOn.Core.EntitiesModel;

namespace CrushOn.Core.Repositories
{
    public interface IProductRepository : IRepository<ProductModel>
    {
        public Task<IEnumerable<ProductModel>> GetAllProducts();
    }
}
