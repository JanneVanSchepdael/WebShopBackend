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
using Microsoft.Extensions.Configuration;

namespace Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IConfiguration _config;

    private readonly ITokenRepository _tokenRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly ICartRepository _cartRepository;

    //Repositories
    public ITokenRepository TokenRepository => _tokenRepository;
    public IUserRepository UserRepository => _userRepository;
    public IProductRepository ProductRepository => _productRepository;
    public IOrderRepository OrderRepository => _orderRepository;
    public ICartRepository CartRepository => _cartRepository;

    public UnitOfWork(DataContext context, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration config)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;

        _tokenRepository = new TokenRepository(_config);
        _userRepository = new UserRepository(_context, _userManager, _signInManager, _tokenRepository, _mapper);
        _productRepository = new ProductRepository(_context, _mapper);
        _orderRepository = new OrderRepository(_context, _mapper);
        _cartRepository = new CartRepository(_context, _mapper);
    }

    public async Task<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
