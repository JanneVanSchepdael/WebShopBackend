namespace Domain;

public class Order
{
    public int Id { get; set; }
    public AppUser User { get; set; }
    public List<Product> Products { get; set; } = new();
    //public string Address { get; set; }
    public DateTime OrderDate { get; set; }

    public Order() { }
    public Order(AppUser user, List<Product> products)
    {
        User = user;
        Products = products;
        OrderDate = DateTime.Now;
    }
}
