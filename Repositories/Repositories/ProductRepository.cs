using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Shared.Cart;
using Shared.Product;
using System.Diagnostics;

namespace Repositories.Repositories;

public class ProductRepository : IProductRepository
{
    public readonly DataContext _context;
    public readonly IMapper _mapper;

    public ProductRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    private IQueryable<Product> GetProductById(int id) => _context.Products
        .AsNoTracking()
        .Where(a => a.Id == id);

    public async Task<ProductResponse.Detail> GetProductDetailAsync(ProductRequest.Detail request)
    {
        ProductResponse.Detail response = new()
        {
            Product = await GetProductById(request.Id)
           .ProjectTo<ProductDto.Detail>(_mapper.ConfigurationProvider)
           .SingleOrDefaultAsync()
        };

        return response;
    }

    public async Task<ProductResponse.Index> GetProductsAsync(ProductRequest.Index request)
    {
        ProductResponse.Index response = new();

        var query = _context.Products.AsQueryable().AsNoTracking();

        // Only displaying products that are available
        query = query.Where(u => u.IsAvailable);

        // Filtering between dates
        var minDate = DateTime.Today.AddDays(-request.MaxDaysOld - 1).ToUniversalTime();
        var maxDate = DateTime.Today.AddDays(-request.MinDaysOld).ToUniversalTime();
        query = query.Where(u => u.ReleaseDate >= minDate && u.ReleaseDate <= maxDate);

        // Search term
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            try
            {
                query = query.Where(x => x.Name.Contains(request.SearchTerm));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return response;
            }
        }

        // Take correct amount of products on the page
        if (request.Page > 0)
        {
            query = query.Skip(request.Amount * (request.Page - 1)).Take(request.Amount);
        }

        // Determine how much products are left for these parameters
        response.TotalAmount = query.Count();
        if (response.TotalAmount == 0) return response;

        // Sort by
        query = request.OrderBy switch
        {
            "new" => query.OrderByDescending(u => u.ReleaseDate),
            _ => query.OrderByDescending(u => u.Name)
        };

        response.Products = await query.Select(x => new ProductDto.Index
        {
            Id = x.Id,
            Name = x.Name,
            Price= x.Price,
            Image= x.Image,
            ReleaseDate = x.ReleaseDate.ToUniversalTime()
        }).ToListAsync();


        return response;
    }
}
