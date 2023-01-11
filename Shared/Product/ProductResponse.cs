using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Product;

// Abstract so there is never an object made of this class
public abstract class ProductResponse
{
    public class Index
    {

    }

    public class Detail
    {
        public ProductDto.Detail Product { get; set; }
    }

    public class Create
    {
        
    }

    public class Edit
    {

    }

    public class Delete
    {

    }

}
