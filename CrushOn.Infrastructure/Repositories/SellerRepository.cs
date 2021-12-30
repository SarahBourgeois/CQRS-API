using System.Collections.Generic;
using System.Threading.Tasks;
using CrushOn.Core.EntitiesModel;
using Microsoft.EntityFrameworkCore;

public class SellerRepository : Repository<SellerModel>, ISellerRepository
{
    public SellerRepository(CrushOnContext crushOnContext) : base(crushOnContext) { }

    public async Task<IEnumerable<SellerModel>> GetAllSellers()
    {
        return await _crushOnContext.Sellers.ToListAsync();
    }
}