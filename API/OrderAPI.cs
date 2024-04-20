using HipHopPizza.Models;
using HipHopPizza.DTO;
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

            app.MapGet("/order/items/{id}", async (HipHopPizzaDbContext db, int id) =>
            {
                var order = await db.Orders
                    .Include(order => order.Items)
                    .ThenInclude(orderItem => orderItem.Item)
                    .SingleOrDefaultAsync(order => order.Id == id);

                var items = order.Items.Select( item => new
                {
                    id = item.Item.Id,
                    name = item.Item.Name,
                    price = item.Item.Price,
                }).ToArray();
                
                return Results.Ok(items);
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
                Order order = await db.Orders.FirstOrDefaultAsync(x => x.Id == addItemDto.OrderId);
                Item item = await db.Items.FirstOrDefaultAsync(x => x.Id == addItemDto.ItemId);
                OrderItem orderItem = await db.OrderItems.FirstOrDefaultAsync(x => x.Item.Id == item.Id && x.Order.Id == order.Id);

                order.Items.Remove(orderItem);
                await db.SaveChangesAsync();
                return Results.Ok();
            });

            app.MapPatch("/order/{id}/addtip", (HipHopPizzaDbContext db, int id, AddTipDto addTipDto) =>
            {
                var orderToUpdate = db.Orders.SingleOrDefault(x => x.Id == id);

                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }

                if (addTipDto.Tip != 0) orderToUpdate.Tip = addTipDto.Tip;

                db.SaveChanges();
                return Results.NoContent();
            });

            app.MapGet("/revenue", async (HipHopPizzaDbContext db) =>
            {
                var totalSum = await db.Orders
                    .Where(order => order.IsComplete)
                    .Select(order => order.Total)
                    .SumAsync();

                return Results.Ok(new { TotalSum = totalSum });
            });
        }
    }
}
