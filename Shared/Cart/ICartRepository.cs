
namespace Shared.Cart;

public interface ICartRepository
{
    Task<CartResponse.Detail> GetCartDetailAsync(CartRequest.Detail request);
    Task<CartResponse.Edit> EditCartAsync(CartRequest.Edit request);
    Task<CartResponse.Edit> AddToCartAsync(CartRequest.Add request);
    
}
