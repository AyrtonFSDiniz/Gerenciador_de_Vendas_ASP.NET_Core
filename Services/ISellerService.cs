using SaleWebMVC.Models;

namespace SaleWebMVC.Services
{
    public interface ISellerService
    {
        Task<List<Seller>> FindAllAsync();
        Task<Seller> FindByIdAsync(int id);
        Task InsertAsync(Seller obj);
        Task RemoveAsync(int id);
        Task UpdateAsync(Seller obj);
        
    }
}
