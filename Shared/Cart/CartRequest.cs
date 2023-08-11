using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Cart;

// Abstract so there is never an object made of this class
public abstract class CartRequest
{
    public class Detail
    {
        public string UserId { get; set; }
    }

    public class Edit
    {
        public CartDto Cart { get; set; }
    }
}
