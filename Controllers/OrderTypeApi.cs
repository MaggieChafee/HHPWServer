using HHPWServer.Models;
namespace HHPWServer.Controllers
{
    public class OrderTypeApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/order-types", (HhpwDbContext db) =>
            {
                return Results.Ok(db.OrderTypes.ToList());
            });
        }
    }
}
