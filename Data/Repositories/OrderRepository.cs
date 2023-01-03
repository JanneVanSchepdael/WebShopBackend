using AutoMapper;
using WebShopAPI.Interfaces.IRepositories;
using WebShopAPI.Models;

namespace WebShopAPI.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly DataContext _context;
        public readonly IMapper _mapper;

        public OrderRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<Product> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersByUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
