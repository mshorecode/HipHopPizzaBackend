using HipHopPizza.Models;

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
        }
    }
}