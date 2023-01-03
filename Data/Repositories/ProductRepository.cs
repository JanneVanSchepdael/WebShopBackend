using AutoMapper;
using WebShopAPI.Interfaces.IRepositories;
using WebShopAPI.Models;

namespace WebShopAPI.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly DataContext _context;
        public readonly IMapper _mapper;

        public ProductRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
