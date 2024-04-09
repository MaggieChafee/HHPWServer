using System.Reflection.Metadata.Ecma335;
using HHPWServer.Models;
namespace HHPWServer.Controllers
{
    public class OrderApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/orders", (HhpwDbContext db) =>
            {
                if (db.Orders == null)
                {
                    return Results.BadRequest();
                }
                return Results.Ok(db.Orders);
            });

            app.MapGet("/orders/{id}", (HhpwDbContext db, int id) =>
            {
                var singleOrder = db.Orders.SingleOrDefault(o => o.Id == id);
                if (singleOrder == null) 
                {
                    return Results.BadRequest();
                }
                return Results.Ok(singleOrder);
            });
        }
    }
}
