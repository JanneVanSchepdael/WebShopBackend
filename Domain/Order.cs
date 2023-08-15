namespace Domain;

public class Order
{
    public int Id { get; set; }
    public AppUser User { get; set; }
    public List<OrderItem> Items { get; set; } = new();
    //public string Address { get; set; }
    public DateTime OrderDate { get; set; }

    public Order() { }
    public Order(AppUser user, List<OrderItem> items)
    {
        User = user;
        Items = items;
        OrderDate = DateTime.UtcNow;
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
    }
}
