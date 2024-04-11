using HipHopPizza.Models;
using HipHopPizza.DTO;
using Microsoft.EntityFrameworkCore;

namespace HipHopPizza.API
{
    public class UserAPIs
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/checkuser", (HipHopPizzaDbContext db, UserAuthDto userAuthDto) =>
            {
                var userUid = db.Users.SingleOrDefault(user => user.Uid == userAuthDto.Uid);

                return userUid == null ? Results.NotFound() : Results.Ok(userUid);
            });
            
            app.MapPost("/register", (HipHopPizzaDbContext db, User user) =>
            {
                db.Users.Add(user);
                db.SaveChanges();
                return Results.Created($"/user/{user.Id}", user);
            });
        }
    }
}