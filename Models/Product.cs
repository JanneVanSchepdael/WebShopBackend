namespace WebShopAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public bool IsAvailable { get; set; }
        public string Description { get; set; }
        public ProductType ProductType { get; set; }

        public Product() { }

        public Product(int id, string name, decimal price, string image, bool isAvailable, string description, ProductType productType)
        {
            Id = id;
            Name = name;
            Price = price;
            Image = image;
            IsAvailable = isAvailable;
            Description = description;
            ProductType = productType;
        }
    }

    public enum ProductType
    {
        Shirt,
        Hoodie,
        Jacket,
    }
}
