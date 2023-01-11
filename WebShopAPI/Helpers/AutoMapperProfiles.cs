using AutoMapper;
using Domain;
using Shared.Cart;
using Shared.Order;
using Shared.Product;
using Shared.User;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // App User
            CreateMap<AppUser, UserDto.Index>();
            CreateMap<AppUser, UserDto.Detail>();
            CreateMap<AppUser, UserDto.Edit>();
            CreateMap<UserRequest.Register, AppUser>();

            // Cart
            CreateMap<Cart, CartDto.Index>();
            CreateMap<Cart, CartDto.Detail>()
                .ForMember(x => x.TotalPrice, y => y.MapFrom(src => 
                src.Products.Sum(x => x.Price * x.Quantity)));
            CreateMap<Cart, CartDto.Create>();
            CreateMap<Cart, CartDto.Edit>();

            // Product
            CreateMap<Product, ProductDto.Index>();
            CreateMap<Product, ProductDto.Detail>();
            CreateMap<Product, ProductDto.Create>();
            CreateMap<Product, ProductDto.Edit>();

            // Order
            CreateMap<Order, OrderDto.Index>();
            CreateMap<Order, OrderDto.Detail>();
            CreateMap<Order, OrderDto.Create>();
            CreateMap<Order, OrderDto.Edit>();
        }
    }
}
