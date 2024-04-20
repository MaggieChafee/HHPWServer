using System.Reflection.Metadata.Ecma335;
using HHPWServer.Models;
namespace HHPWServer.Controllers
{
    public class UserApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/checkuser/{uid}", (HhpwDbContext db, string uid) =>
            {
                User user = db.Users.FirstOrDefault(x => x.Uid == uid);
                if (user == null)
                {
                    return Results.BadRequest("Does not exist.");
                }
                return Results.Ok(user);
            });
        }
    }
}
