using System.Reflection.Metadata.Ecma335;
using HHPWServer.Models;
namespace HHPWServer.Controllers
{
    public class UserApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/users/{id}", (HhpwDbContext db, int id) =>
            {
                User user = db.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return Results.BadRequest("Does not exist.");
                }
                return Results.Ok(user);
            });
        }
    }
}
