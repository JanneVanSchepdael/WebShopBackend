﻿namespace Shared.User;

// Abstract so there is never an object made of this class
public abstract class UserRequest
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Register 
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }

    public class Edit
    {
       public UserDto.Edit User { get; set; }
    }
}
