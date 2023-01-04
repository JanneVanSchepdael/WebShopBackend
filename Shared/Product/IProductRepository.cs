
namespace Shared.Product;

public interface IProductRepository
{
    Task<ProductResponse.Detail> GetProductById(ProductRequest.Detail request);
}
