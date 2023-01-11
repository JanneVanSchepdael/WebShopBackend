using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shared.Cart;
using Shared.Order;

namespace Repositories.Repositories;

public class OrderRepository : IOrderRepository
{
    public readonly DataContext _context;
    public readonly DbSet<Order> _orders;
    public readonly IMapper _mapper;

    public OrderRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _orders = context.Orders;
        _mapper = mapper;
    }

    private IQueryable<Order> GetOrdersByUserId(string id) => _orders
       .AsNoTracking()
       .OrderByDescending(m => m.OrderDate)
       .Where(o => o.User.Id == id).Include(a => a.Products);

    public async Task<OrderResponse.Detail> GetOrdersByUserAsync(OrderRequest.Detail request)
    {
        OrderResponse.Detail response = new()
        {
            Orders = await GetOrdersByUserId(request.UserId)
                .ProjectTo<OrderDto.Detail>(_mapper.ConfigurationProvider)
                .ToListAsync()
        };

        return response;
    }

    public Task<OrderResponse.Create> AddOrderAsync(OrderRequest.Create request)
    {
        throw new NotImplementedException();
    }
}
