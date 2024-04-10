using System.ComponentModel.DataAnnotations;

namespace HipHopPizza.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public int CustomerPhone { get; set; }
    public int OrderTypeId { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Tip { get; set; }
    public decimal Total { get; set; }
    public DateTime? OrderDate { get; set; }
    public bool IsComplete { get; set; }
}

