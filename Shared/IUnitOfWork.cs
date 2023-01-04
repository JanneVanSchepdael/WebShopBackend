using Shared.Cart;
using Shared.Order;
using Shared.Product;
using Shared.User;

namespace Shared;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IProductRepository ProductRepository { get; }
    IOrderRepository OrderRepository { get; }
    ICartRepository CartRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
}
