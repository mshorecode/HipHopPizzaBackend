using System.ComponentModel.DataAnnotations;

namespace HipHopPizza.Models;

public class User
{
    public int Id { get; set; }
    public string? DisplayName { get; set; }
    public string? Uid { get; set; }
}

