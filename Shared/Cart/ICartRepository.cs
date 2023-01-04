
namespace Shared.Cart;

public interface ICartRepository
{
    Task<CartResponse.Detail> GetCartById(CartRequest.Detail request);
}
