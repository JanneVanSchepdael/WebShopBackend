using AutoMapper;
using Persistence;
using Shared.User;
using Shared.Product;
using Shared.Order;
using Shared.Cart;
using Repositories.Repositories;
using Shared;
using Domain;
using Microsoft.AspNetCore.Identity;
using Shared.Token;

namespace Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    
    //Repositories
    public IUserRepository UserRepository => new UserRepository(_context, _mapper);
    public IProductRepository ProductRepository => new ProductRepository(_context, _mapper);
    public IOrderRepository OrderRepository => new OrderRepository(_context, _mapper);
    public ICartRepository CartRepository => new CartRepository(_context, _mapper);

    public UnitOfWork(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }
}
