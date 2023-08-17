using FluentValidation;

namespace Shared.User;

public abstract class UserDto
{
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
