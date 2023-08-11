using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Cart;

// Abstract so there is never an object made of this class
public abstract class CartRequest
{
    public class Add
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class Detail
    {
        public string UserId { get; set; }
    }

    public class Edit
    {
        public CartDto.Edit Cart { get; set; }
    }
}
