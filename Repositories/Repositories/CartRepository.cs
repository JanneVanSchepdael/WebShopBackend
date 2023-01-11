using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shared.Cart;

namespace Repositories.Repositories;

public class CartRepository : ICartRepository
{
    public readonly DataContext _context;
    public readonly DbSet<Cart> _carts;
    public readonly IMapper _mapper;

    public CartRepository(DataContext context, IMapper mapper)
    {
        this._context = context;
        this._carts = context.Carts;
        this._mapper = mapper;
    }

    private IQueryable<Cart> GetCartByUserId(string id) => _carts
        .AsNoTracking()
        .Where(a => a.UserId == id).Include(a => a.Products);

    public async Task<CartResponse.Detail> GetCartDetailAsync(CartRequest.Detail request)
    {
        CartResponse.Detail response = new()
        {
            Cart = await GetCartByUserId(request.UserId)
            .ProjectTo<CartDto.Detail>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync()
        };

        return response;
    }

    public Task<CartResponse.Create> AddCartAsync(CartRequest.Create request)
    {
        throw new NotImplementedException();
    }

    public Task<CartResponse.Edit> EditCartAsync(CartRequest.Edit request)
    {
        throw new NotImplementedException();
    }
}
