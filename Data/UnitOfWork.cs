using WebShopAPI.Interfaces.IRepositories;
using WebShopAPI.Interfaces;
using AutoMapper;
using WebShopAPI.Data.Repositories;

namespace WebShopAPI.Data
{
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
}
