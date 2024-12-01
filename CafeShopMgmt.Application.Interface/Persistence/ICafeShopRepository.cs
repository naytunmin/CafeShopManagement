using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Domain.Entities;

namespace CafeShopMgmt.Application.Interface.Persistence
{
    public interface ICafeShopRepository
    {
        Task<List<CafeShopDto>> GetCafeShopAsync(string? location);
        Task<bool> AddAsync(CafeShop cafeshop);
        Task<bool> UpdateAsync(CafeShop cafeshop);
        Task<bool> DeleteAsync(CafeShop cafeshop);
        Task<CafeShop> GetCafeShopByIdAsync(Guid shopId);
    }
}
