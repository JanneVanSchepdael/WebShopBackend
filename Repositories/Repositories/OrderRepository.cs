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
       .Where(o => o.User.Id == id).Include(a => a.Items);

    private IQueryable<AppUser> GetUserById(string id) => _context.Users
       .AsNoTracking()
       .Where(a => a.Id == id);

    public async Task<OrderResponse.Index> GetOrdersByUserAsync(OrderRequest.Index request)
    {
        OrderResponse.Index response = new();


        response.Orders = await GetOrdersByUserId(request.UserId)
                .ProjectTo<OrderDto.Index>(_mapper.ConfigurationProvider)
                .ToListAsync();

        return response;
    }

    public async Task<OrderResponse.Create> AddOrderAsync(OrderRequest.Create request)
    {
        OrderResponse.Create response = new();

        AppUser user = await GetUserById(request.Order.UserId).SingleOrDefaultAsync();
        var items = _mapper.Map<List<OrderItem>>(request.Order.Items);

        var order = new Order(user, items);

        _orders.Add(order);
        await _context.SaveChangesAsync();

        response.Id = order.Id;
        return response;
    }
}
