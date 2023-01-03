namespace WebShopAPI.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public List<Product> Products { get; set; }
        public DateTime DateCreated { get; set; }

        //Total price?

        public Cart() { }
    }
}
