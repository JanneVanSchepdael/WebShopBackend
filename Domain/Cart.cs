using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Cart
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public List<OrderItem> Items { get; set; }
    public DateTime DateCreated { get; set; }

    public Cart() {
        Items = new();
        DateCreated = DateTime.Now;
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
    }

    public void RemoveItem(OrderItem item)
    {
        Items.Remove(item);
    }
}
