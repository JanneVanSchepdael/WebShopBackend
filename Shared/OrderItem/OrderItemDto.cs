using Shared.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.OrderItem
{
    public class OrderItemDto
    {
        public class Index
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        public class Create
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        public class Edit
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        public class Delete
        {
            public int Id { get; set; }
        }   
    }
}
