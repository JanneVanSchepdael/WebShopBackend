using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shared.Order;
using static System.Net.Mime.MediaTypeNames;

namespace Repositories.Repositories;

public class OrderRepository : IOrderRepository
{
    public readonly DataContext _context;
    public readonly DbSet<Order> _orders;
    public readonly DbSet<Cart> _carts;
    public readonly IMapper _mapper;

    public OrderRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _orders = context.Orders;
        _carts = context.Carts;
        _mapper = mapper;
    }

    private IQueryable<Order> GetOrdersByUserId(string id) => _orders
       .AsNoTracking()
       .OrderByDescending(m => m.OrderDate)
       .Where(o => o.User.Id == id).Include(a => a.Items);

    public async Task<OrderResponse.Index> GetOrdersByUserAsync(OrderRequest.Index request)
    {
        OrderResponse.Index response = new()
        {
            Orders = await GetOrdersByUserId(request.UserId)
                .ProjectTo<OrderDto.Index>(_mapper.ConfigurationProvider)
                .ToListAsync()
        };

        return response;
    }

    public async Task<OrderResponse.Create> AddOrderAsync(OrderRequest.Create request)
    {
        OrderResponse.Create response = new();

        AppUser user = await _context.Users.Include(u => u.Cart)
                            .Where(u => u.Id == request.Order.UserId)
                            .SingleOrDefaultAsync();

        var order = _mapper.Map<Order>(request.Order);
        order.UserId = user.Id;

        _orders.Add(order);
        _carts.Remove(user.Cart);
        user.Cart = new Cart();

        response.Id = order.Id;
        return response;
    }
}
