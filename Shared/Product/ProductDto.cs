using FluentValidation;

namespace Shared.Product
{
    public abstract class ProductDto
    {
        public class Index
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public decimal Price { get; set; }
            public DateTime ReleaseDate { get; set; }
        }

        public class Detail
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public decimal Price { get; set; }
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
