using HipHopPizza.Models;
using HipHopPizza.DTO;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

namespace HipHopPizza.API
{
    public class OrderAPIs
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/orders", (HipHopPizzaDbContext db) =>
            {
                return db.Orders.ToList();
            });

            app.MapGet("/orders/{id}", (HipHopPizzaDbContext db, int id) =>
            {
                return db.Orders
                         .Include(order => order.Items)
                         .ThenInclude(orderItem => orderItem.Item)
                         .SingleOrDefault(order => order.Id == id);
            });

            app.MapPost("/orders", (HipHopPizzaDbContext db, Order order) =>
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return Results.Created($"/orders/{order.Id}", order);
            });
            
            app.MapPatch("/orders/{id}", (HipHopPizzaDbContext db, int id, OrderDto order) =>
            {
                var orderToUpdate = db.Orders.SingleOrDefault(o => o.Id == id);

                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }
                
                if (!string.IsNullOrEmpty(order.CustomerName)) orderToUpdate.CustomerName = order.CustomerName;
                if (!string.IsNullOrEmpty(order.CustomerEmail)) orderToUpdate.CustomerEmail = order.CustomerEmail;
                if (!string.IsNullOrEmpty(order.CustomerPhone)) orderToUpdate.CustomerPhone = order.CustomerPhone;

                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapPost("order/additem", async (HipHopPizzaDbContext db, AddItemDto addItemDto) =>
            {
                Order order = await db.Orders.FirstOrDefaultAsync(x => x.Id == addItemDto.OrderId);
                Item item = await db.Items.FirstOrDefaultAsync(x => x.Id == addItemDto.ItemId);
                
                OrderItem orderItem = new()
                {
                    Id = 0,
                    Item = item,
                    Order = order
                };

                order.Items.Add(orderItem);

                await db.SaveChangesAsync();

                return Results.Ok();
            });

            app.MapPost("/order/removeitem", async (HipHopPizzaDbContext db, AddItemDto addItemDto) =>
            {

            });
        }
    }
}