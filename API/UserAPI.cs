using HipHopPizza.Models;
using HipHopPizza.DTO;

namespace HipHopPizza.API
{
    public class UserAPIs
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/checkuser", (HipHopPizzaDbContext db, User user) =>
            {
                var userUid = db.Users.SingleOrDefault(u => u.Uid == user.Uid);

                if (userUid != null)
                {
                    return Results.Ok(userUid);
                }

                User response = new User
                {
                    DisplayName = user.DisplayName,
                    Uid = user.Uid
                };
                
                db.Users.Add(response);
                db.SaveChanges();

                return Results.Ok(response);
            });
        }
    }
}