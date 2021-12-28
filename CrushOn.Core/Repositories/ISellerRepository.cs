using System.Collections.Generic;
using System.Threading.Tasks;
using CrushOn.Core.Entities;

public interface ISellerRepository : IRepository<SellerModel>
{
    public Task<IEnumerable<SellerModel>> GetAllSellers();
}