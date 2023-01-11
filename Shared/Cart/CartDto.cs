using FluentValidation;
using Shared.Product;

namespace Shared.Cart
{
    public abstract class CartDto
    {
        public class Index
        {

        }

        public class Detail
        {
            public int Id { get; set; }
            public IEnumerable<ProductDto.Index> Products { get; set; }
            public decimal TotalPrice { get; set; }
        }

        public class Create
        {
            //public int Id { get; set; }

            public class Validator : AbstractValidator<Create>
            {
                public Validator()
                {
                    //RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
                }
            }
        }

        public class Edit
        {
            // Props

            public class Validator : AbstractValidator<Edit>
            {
                public Validator()
                {
                    //RuleFor
                }
            }
        }
    }
}
