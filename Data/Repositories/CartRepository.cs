using AutoMapper;
using WebShopAPI.Interfaces.IRepositories;
using WebShopAPI.Models;

namespace WebShopAPI.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        public readonly DataContext _context;
        public readonly IMapper _mapper;

        public CartRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<Product> GetCartById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
