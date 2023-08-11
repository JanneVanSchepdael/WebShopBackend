using FluentValidation;

namespace Shared.User;

public abstract class UserDto
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
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class Validator : AbstractValidator<Edit>
        {
            public Validator()
            {
                //RuleFor
            }
        }
    }
}
