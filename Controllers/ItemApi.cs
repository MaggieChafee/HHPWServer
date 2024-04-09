using HHPWServer.Models;

namespace HHPWServer.Controllers
{
    public class ItemApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/orders/{orderId}/orderItems", (HhpwDbContext db, int orderId) =>
            {
                var orderItems = db.OrderItems.Where(x => x.OrderId == orderId).Select(x => x.ItemId).ToList();
                var items = db.Items.Where(i => orderItems.Contains(i.Id)).ToList();
                if (items == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(items);
            });

            app.MapPost("/addToOrder/{orderId}/item/{itemId}", (HhpwDbContext db, int orderId, int itemId) =>
            {
                var newOrderItem = new OrderItem
                {
                    OrderId = orderId,
                    ItemId = itemId,
                };
                db.OrderItems.Add(newOrderItem);
                db.SaveChanges();
                return Results.Ok("Item successfully added to Order.");
            });

            app.MapDelete("/orders/deleteItem/{orderItemId}", (HhpwDbContext db, int orderItemId) =>
            {
                var orderItemToDelete = db.OrderItems.FirstOrDefault(x => x.Id ==  orderItemId);
                if (orderItemToDelete == null) 
                {
                    return Results.NotFound();
                }
                db.OrderItems.Remove(orderItemToDelete);
                db.SaveChanges();
                return Results.Ok("Item deleted");
            });
        }
    }
}
