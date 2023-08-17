using Microsoft.AspNetCore.Identity;

namespace Domain;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Name { get { return FirstName + " " + LastName; } }
    public Cart Cart { get; set; }
    public ICollection<Order> Orders { get; set; }

    private AppUser() { Cart = new Cart(); }

    public AppUser(string email, string firstName, string lastName) : this()
    {
        Email = email;
        UserName = email;
        FirstName = firstName; 
        LastName = lastName;
    }
}
