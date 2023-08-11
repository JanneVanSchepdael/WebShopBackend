using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Product;

// Abstract so there is never an object made of this class
public abstract class ProductRequest
{
    public class Index
    {
        public string SearchTerm { get; set; }
        public int Amount { get; set; } = 9;
        public int Page { get; set; }
        public int MinDaysOld { get; set; } = -1;
        public int MaxDaysOld { get; set; } = 365;
        public string OrderBy { get; set; }

    }

    public class Detail
    {
        public int Id { get; set; }

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
