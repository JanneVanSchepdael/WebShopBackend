namespace Domain;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public bool IsAvailable { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }

    public ProductType ProductType { get; set; }

    public Product() { }

    public Product(string name, decimal price, string image, bool isAvailable, string description, ProductType productType, DateTime releaseDate)
    {
        Name = name;
        Price = price;
        Image = image;
        IsAvailable = isAvailable;
        Description = description;
        ProductType = productType;
        ReleaseDate = releaseDate;
    }
}

public enum ProductType
{
    Shirt,
    Hoodie,
    Jacket,
}
