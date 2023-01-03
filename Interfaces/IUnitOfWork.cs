using WebShopAPI.Interfaces.IRepositories;

namespace WebShopAPI.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        ICartRepository CartRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}
