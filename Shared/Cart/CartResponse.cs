using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Cart;

// Abstract so there is never an object made of this class
public abstract class CartResponse
{
    public class Detail
    {
        public CartDto.Detail Cart { get; set; }
    }

    public class Edit
    {
        public CartDto.Edit Cart { get; set; }
    }
}
