using System.ComponentModel.DataAnnotations;

namespace HipHopPizza.Models;

public class Order
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerPhone { get; set; }
    public int OrderTypeId { get; set; }
    public decimal Tip { get; set; }
    public DateTime? OrderDate { get; set; }
    public bool IsComplete { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    public decimal? Subtotal
    {
        get
        {
            return Items.Sum(item => item.Price);
        }
    }

    public decimal? Total
    {
        get
        {
            return Subtotal + Tip;
        }
    }
}
