using System;
using System.Threading.Tasks;
using CrushOn.Core.Entities;

namespace CrushOn.Infrastructure.Abstract.Business.Seller
{
    public interface ISellerBusiness
    {
        Task<SellerModel> CreateNewSellerAsync(SellerDto sellerDto);
    }
}
