using FluentValidation;
using Shared.OrderItem;
using Shared.Product;

namespace Shared.Cart;

public abstract class CartDto
{
    public class Edit
    {
        public string UserId { get; set; }
        public IEnumerable<OrderItemDto.Index> Items { get; set; }
    }

    public class Detail
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IEnumerable<OrderItemDto.Detail> Items { get; set; }
    }
}
