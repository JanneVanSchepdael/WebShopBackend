using AutoMapper;
using Persistence;
using Shared.Order;

namespace Repositories.Repositories;

public class OrderRepository : IOrderRepository
{
    public readonly DataContext _context;
    public readonly IMapper _mapper;

    public OrderRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<OrderResponse.Detail> GetOrderById(OrderRequest.Detail request)
    {
        throw new NotImplementedException();
    }
}
