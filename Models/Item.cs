using System.ComponentModel.DataAnnotations;

namespace HipHopPizza.Models;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public List<OrderItem> Orders { get; set; } = new List<OrderItem>();
}

