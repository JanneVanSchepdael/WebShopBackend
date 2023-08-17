namespace Domain;

public class Order
{
    public int Id { get; set; }
    public AppUser User { get; set; }
    public string UserId { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    public DateTime OrderDate { get; set; }

    public Order()
    {
        OrderDate = DateTime.UtcNow;
    }
    public Order(AppUser user, List<OrderItem> items) : this()
    {
        User = user;
        Items = items;
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
    }
}
