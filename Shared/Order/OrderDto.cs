using FluentValidation;
using Shared.OrderItem;
using Shared.Product;

namespace Shared.Order
{
    public abstract class OrderDto
    {
        public class Index
        {
            public int Id { get; set; }
            public DateTime OrderDate { get; set; }
            public int AmountOfProducts { get; set; }
            public decimal TotalPrice { get; set; }
        }

        public class Detail
        {
            public int Id { get; set; }
            public IEnumerable<OrderItemDto.Index> Products { get; set; }
            public DateTime OrderDate { get; set; }
            public decimal TotalPrice { get; set; }
        }

        public class Create
        {
            public string UserId { get; set; }
            public List<OrderItemDto.Index> Items { get; set; } = new();
        }
    }
}
