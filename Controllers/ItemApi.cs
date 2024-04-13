using HHPWServer.Models;
using Microsoft.AspNetCore.Mvc.Routing;

namespace HHPWServer.Controllers
{
    public class ItemApi
    {
        public static void Map(WebApplication app)
        {
            // get all items
            app.MapGet("/items", (HhpwDbContext db) =>
            {
                var allItems = db.OrderItems.ToList();
                if (allItems == null)
                {
                    return Results.Empty;
                }
                return Results.Ok(allItems);
            });

            // get order items of a single order
            app.MapGet("/orders/{orderId}/order-items", (HhpwDbContext db, int orderId) =>
            {
                var orderItems = db.OrderItems
                    .Where(x => x.OrderId == orderId)
                    .Select(x => x.Item)
                    .ToList();
                
                if (orderItems == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(orderItems);
            });
            // add item to order
            app.MapPost("/add-to-order/{orderId}/item/{itemId}", (HhpwDbContext db, int orderId, int itemId) =>
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
            // delete item from order
            app.MapDelete("/orders/{orderId}/delete-item/{itemId}", (HhpwDbContext db, int itemId, int orderId) =>
            {
                var orderItemToDelete = db.OrderItems.FirstOrDefault(x => x.OrderId == orderId && x.ItemId == itemId );
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
