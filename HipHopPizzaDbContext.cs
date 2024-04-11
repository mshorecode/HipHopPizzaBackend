using Microsoft.EntityFrameworkCore;
using HipHopPizza.Models;

public class HipHopPizzaDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<OrderType> OrderTypes { get; set; }

    public HipHopPizzaDbContext(DbContextOptions<HipHopPizzaDbContext> context) : base(context)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(new Item[]
        {
            new Item { Id = 1, Name = "Cheeseburger Pizza", Price = 14, ImageUrl = "https://s3-media0.fl.yelpcdn.com/bphoto/OQpAaFjU-KVpCpljCoHfVQ/o.jpg" },
            new Item { Id = 2, Name = "Cold Veggie Pizza", Price = 10, ImageUrl  = "https://cdn.cdkitchen.com/recipes/images/2010/07/11102-1568-mx.jpg" },
            new Item { Id = 3, Name = "Pepperoni Lovers Pizza", Price = 12, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSN37d5qV3N4tAsDsCuihjbnWjV1xNccQy0h2TjR9C_Q&s" },
            new Item { Id = 4, Name = "Cheese Pizza", Price = 10, ImageUrl = "https://fatapplesrestaurant.com/cdn/shop/products/five-cheese_800x.jpg?v=1612571720" },
            new Item { Id = 5, Name = "The Meat Sweats Wings", Price = 22, ImageUrl = "https://www.recipetineats.com/wp-content/uploads/2019/01/Baked-Buffalo-Wings_0.jpg" },
            new Item { Id = 6, Name = "Honey BBQ Wings", Price = 17, ImageUrl = "https://www.smoking-meat.com/image-files/honey-barbecue-smoked-wings-575x384-1-500x375.jpg" },
            new Item { Id = 7, Name = "Crispy Cajun Wings", Price = 15, ImageUrl = "https://alldayidreamaboutfood.com/wp-content/uploads/2022/10/Crispy-Cajun-Wings.jpg" },
            new Item { Id = 8, Name = "Sweet and Spicy Wings", Price = 20, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSabgmlhTm0aFVa9CKI41cLw-EGA_A87x7jY-4gqkeTlA&s" },
        });

        modelBuilder.Entity<OrderType>().HasData(new OrderType[]
        {
            new OrderType { Id = 1, Type = "Walk-In" },
            new OrderType { Id = 2, Type = "Call-In" },
        });

        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order { Id = 1, CustomerName = "Johnny Saniat", CustomerEmail = "johnnyyourmomcalled@johnnybusiness.net", CustomerPhone = "615-555-5512", OrderTypeId = 1, Tip = 10, OrderDate = new DateTime(), IsComplete = true },
            new Order { Id = 2, CustomerName = "Keana Cobarde", CustomerEmail = "keanabusiness@gmail.com", CustomerPhone = "615-555-1255", OrderTypeId = 2, Tip = 5, OrderDate = new DateTime(), IsComplete = true },
            new Order { Id = 3, CustomerName = "Greg Markus", CustomerEmail = "uevadrankbaileys4rmashu@yahoo.com", CustomerPhone = "615-555-2782", OrderTypeId = 1, Tip = 8, OrderDate = new DateTime(), IsComplete = false },
            new Order { Id = 4, CustomerName = "Ryan Shore", CustomerEmail = "number1grump@outlook.com", CustomerPhone = "615-555-7893", OrderTypeId = 2, Tip = 2, OrderDate = new DateTime(), IsComplete = false },
        });
    }
}