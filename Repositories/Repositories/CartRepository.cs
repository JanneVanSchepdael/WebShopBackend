using AutoMapper;
using Persistence;
using Shared.Cart;

namespace Repositories.Repositories;

public class CartRepository : ICartRepository
{
    public readonly DataContext _context;
    public readonly IMapper _mapper;

    public CartRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<CartResponse.Detail> GetCartById(CartRequest.Detail request)
    {
        throw new NotImplementedException();
    }
}
