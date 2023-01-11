namespace Domain;

public class Cart
{
    public int Id { get; set; }
    public AppUser User { get; set; }
    public string UserId { get; set; }
    public List<Product> Products { get; set; }
    public DateTime DateCreated { get; set; }

    public Cart() {
        Products = new();
        DateCreated = DateTime.Now;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        Products.Remove(product);
    }
}
