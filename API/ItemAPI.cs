using HipHopPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace HipHopPizza.API
{
    public class ItemAPIs
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/items", (HipHopPizzaDbContext db) =>
            {
                return db.Items.ToList();
            });
        }
    }
}

