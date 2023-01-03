using WebShopAPI.Models;

namespace WebShopAPI.Interfaces.IRepositories
{
    public interface ICartRepository
    {
        Task<Product> GetCartById(int id);
    }
}
