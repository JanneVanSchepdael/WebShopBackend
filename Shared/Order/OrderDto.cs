using FluentValidation;

namespace Shared.Order
{
    public abstract class OrderDto
    {
        public class Index
        {

        }

        public class Detail
        {

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
