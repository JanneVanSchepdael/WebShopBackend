
namespace Shared.Cart;

public interface ICartRepository
{
    Task<CartResponse.Detail> GetCartDetailAsync(CartRequest.Detail request);
    Task<CartResponse.Create> AddCartAsync(CartRequest.Create request);
    Task<CartResponse.Edit> EditCartAsync(CartRequest.Edit request);
    
}
