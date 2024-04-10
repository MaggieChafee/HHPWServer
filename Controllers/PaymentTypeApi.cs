using HHPWServer.Models;
namespace HHPWServer.Controllers
{
    public class PaymentTypeApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/payment-types", (HhpwDbContext db) =>
            {
                return Results.Ok(db.PaymentTypes.ToList());
            });
        }
    }
}
