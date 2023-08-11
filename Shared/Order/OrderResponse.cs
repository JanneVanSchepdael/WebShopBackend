using Shared.Product;

namespace Shared.Order;

// Abstract so there is never an object made of this class
public abstract class OrderResponse
{
    public class Index
    {
        public IEnumerable<OrderDto.Index> Orders { get; set; }
    }

    public class Detail
    {
        public int Id { get; set; }
        public IEnumerable<OrderDto.Detail> Orders { get; set; }
    }

    public class Create
    {
        public int Id { get; set; }
    }
}
