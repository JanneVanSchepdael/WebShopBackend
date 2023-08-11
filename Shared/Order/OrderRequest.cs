using Shared.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Order;

// Abstract so there is never an object made of this class
public abstract class OrderRequest
{
    public class Index
    {
        public string UserId { get; set; }

    }

    public class Detail
    {
        public string UserId { get; set; }

    }

    public class Create
    {
        public OrderDto.Create Order { get; set; }
    }
}
