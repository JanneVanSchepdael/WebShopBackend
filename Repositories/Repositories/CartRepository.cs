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
        .Where(a => a.UserId == id).Include(a => a.Items);

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

    public async Task<CartResponse.Edit> AddToCartAsync(CartRequest.Add request)
    {
        CartResponse.Edit response = new();

        Cart cart = await GetCartByUserId(request.UserId)
            .SingleOrDefaultAsync();

        if (cart != null)
        {
            var item = cart.Items.FirstOrDefault(a => a.ProductId == request.ProductId);

            if (item != null)
                item.Quantity += request.Quantity;
            else
            {
                var product = await _context.Products.FindAsync(request.ProductId);

                if (product != null)
                {
                    var newItem = new OrderItem(product, request.Quantity);
                    cart.Items.Add(newItem);
                }
            }
        }

        await _context.SaveChangesAsync();

        response.Cart = await GetCartByUserId(request.UserId)
            .ProjectTo<CartDto.Edit>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();

        return response;

    }
    
    public async Task<CartResponse.Edit> EditCartAsync(CartRequest.Edit request)
    {
        CartResponse.Edit response = new();

        Cart cart = await GetCartByUserId(request.Cart.UserId)
            .SingleOrDefaultAsync();

        if (cart != null)
        {
            // Remove products that aren't in the updated cart (both collection & context)
            var updatedItemIds = request.Cart.Items.Select(a => a.Id).ToList();
            var itemsToRemove = cart.Items.Where(a => !updatedItemIds.Contains(a.Id)).ToList();

            foreach (var item in itemsToRemove)
            {
                cart.Items.Remove(item);
                _context.OrderItems.Remove(item);
            }

            // Manually loop through the products in the request and update the corresponding products in the cart
            foreach (var updatedItem in request.Cart.Items)
            {
                var existingItem = cart.Items.FirstOrDefault(p => p.Id == updatedItem.Id);

                if (existingItem != null)
                    _mapper.Map(updatedItem, existingItem);
                else
                {
                    var product = await _context.Products.FindAsync(updatedItem.ProductId);

                    if(product != null)
                    {
                        var item = _mapper.Map<OrderItem>(updatedItem);
                        item.ProductId = product.Id;
                        cart.Items.Add(item);

                    }
                }
            }

            await _context.SaveChangesAsync();
            response.Cart = _mapper.Map<CartDto.Edit>(cart);
        }

        return response;
    }
}
