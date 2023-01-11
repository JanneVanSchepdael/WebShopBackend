using AutoMapper;
using Persistence;
using Shared.Product;

namespace Repositories.Repositories;

public class ProductRepository : IProductRepository
{
    public readonly DataContext _context;
    public readonly IMapper _mapper;

    public ProductRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<ProductResponse.Detail> GetProductDetailAsync(ProductRequest.Detail request)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponse.Index> GetProductsAsync(ProductRequest.Index request)
    {
        throw new NotImplementedException();
    }
}
