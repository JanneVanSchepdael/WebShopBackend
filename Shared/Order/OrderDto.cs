using FluentValidation;
using Shared.Product;

namespace Shared.Order
{
    public abstract class OrderDto
    {
        public class Index
        {
            public int Id { get; set; }
            public DateTime OrderDate { get; set; }
        }

        public class Detail
        {
            public int Id { get; set; }
            public IEnumerable<ProductDto.Index> Products { get; set; }
            public DateTime OrderDate { get; set; }
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
