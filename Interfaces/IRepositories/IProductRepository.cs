using WebShopAPI.Models;

namespace WebShopAPI.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
    }
}
