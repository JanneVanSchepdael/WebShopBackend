namespace Shared.User;

// Abstract so there is never an object made of this class
public abstract class UserRequest
{
    public class Index
    {

    }

    public class Detail
    {

    }

    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    // TODO: Add Fluent Validation
    public class Register 
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Edit
    {

    }
}
