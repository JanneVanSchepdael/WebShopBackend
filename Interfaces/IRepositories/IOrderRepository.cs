using WebShopAPI.Models;

namespace WebShopAPI.Interfaces.IRepositories
{
    public interface IOrderRepository
    {
        Task<Product> GetOrderById(int id);
        Task<List<Order>> GetOrdersByUser(int userId);
    }
}
