using AutoMapper;
using Domain;
using Shared.Cart;
using Shared.Order;
using Shared.OrderItem;
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
            CreateMap<UserDto.Edit, AppUser>();

            // Cart
            CreateMap<Cart, CartDto>()
                .ReverseMap();


            // Product
            CreateMap<Product, ProductDto.Index>();
            CreateMap<Product, ProductDto.Detail>();
            CreateMap<Product, ProductDto.Create>();
            CreateMap<Product, ProductDto.Edit>();
            CreateMap<ProductDto.Index, Product>();

            // OrderItem
            CreateMap<OrderItem, OrderItemDto.Index>()
                .ForMember(x => x.ProductId, y => y.MapFrom(src => src.Product.Id))
                .ReverseMap();

            // Order
            CreateMap<Order, OrderDto.Index>()
                .ForMember(x => x.AmountOfProducts, y => y.MapFrom(src =>
                    src.Items.Sum(x => x.Quantity)))
                .ForMember(x => x.TotalPrice, y => y.MapFrom(src =>
                src.Items.Sum(x => x.Product.Price * x.Quantity)));
        }
    }
}
