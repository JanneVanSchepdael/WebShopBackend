using FluentValidation;
using Shared.OrderItem;
using Shared.Product;

namespace Shared.Cart;

public class CartDto
{
    public string UserId { get; set; }
    public IEnumerable<OrderItemDto.Index> Items { get; set; }
}
