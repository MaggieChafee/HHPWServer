using HHPWServer.Models;
namespace HHPWServer.Controllers
{
    public class OrderTypeApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/orderTypes", (HhpwDbContext db) =>
            {
                return Results.Ok(db.OrderTypes.ToList());
            });
        }
    }
}
