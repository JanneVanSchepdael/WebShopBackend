using Shared.Cart;
using Shared.Order;
using Shared.Product;
using Shared.Token;
using Shared.User;

namespace Shared;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IProductRepository ProductRepository { get; }
    IOrderRepository OrderRepository { get; }
    ICartRepository CartRepository { get; }
    ITokenRepository TokenRepository { get; }
    Task<bool> Complete();
    bool HasChanges();
}
