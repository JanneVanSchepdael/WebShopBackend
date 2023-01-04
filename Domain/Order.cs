namespace Domain;

public class Order
{
    public int Id { get; set; }
    public AppUser User { get; set; }
    public List<Product> Products { get; set; }
    public string Address { get; set; }
    public DateTime OrderDate { get; set; }
}
