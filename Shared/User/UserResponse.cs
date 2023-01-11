using Shared.Cart;
using Shared.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.User;

// Static so there is never an object made of this class
public static class UserResponse
{
    public class Index
    {

    }

    public class Detail
    {
        public UserDto.Detail User { get; set; }
    }

    public class Login
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public CartDto.Detail Cart { get; set; }
        public OrderDto.Detail Orders { get; set; }
    }

    public class Register
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }

    public class Edit
    {

    }

    public class Delete
    {

    }

}
