
namespace Shared.Product;

public interface IProductRepository
{
    Task<ProductResponse.Index> GetProductsAsync(ProductRequest.Index request);
    Task<ProductResponse.Detail> GetProductDetailAsync(ProductRequest.Detail request);
}
