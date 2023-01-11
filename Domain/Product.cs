namespace Domain;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public bool IsAvailable { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; } = 0;
    public ProductType ProductType { get; set; }

    public Product() { }

    public Product(string name, decimal price, string image, bool isAvailable, string description, int quantity, ProductType productType)
    {
        Name = name;
        Price = price;
        Image = image;
        IsAvailable = isAvailable;
        Description = description;
        Quantity = quantity;
        ProductType = productType;
    }
}

public enum ProductType
{
    Shirt,
    Hoodie,
    Jacket,
}
