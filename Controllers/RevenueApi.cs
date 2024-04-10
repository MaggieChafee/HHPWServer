namespace HHPWServer.Controllers
{
    public class RevenueApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/revenue", (HhpwDbContext db) =>
            {
                var revenue = db.Orders
                    .Where(x => x.OrderOpen == false)
                    .Sum(x => x.OrderTotal);
                if (revenue == null)
                {
                    return Results.BadRequest();
                }
                return Results.Ok(revenue);
            });
        }
    }
}
