using System.Reflection.PortableExecutable;
using HHPWServer.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace HHPWServer.Controllers
{
    public class ItemApi
    {
        public static void Map(WebApplication app)
        {
            // get all items
            app.MapGet("/items", (HhpwDbContext db) =>
            {
                var allItems = db.Items.OrderBy(x => x.ItemName).ToList();
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
                    .Select(x => new
                    {
                        x.Id,
                        x.Item,
                        x.Notes,
                    })
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
            app.MapDelete("/orders/delete-item/{orderItemId}", (HhpwDbContext db, int orderItemId) =>
            {
                var orderItemToDelete = db.OrderItems.FirstOrDefault(x => x.Id == orderItemId );
                if (orderItemToDelete == null) 
                {
                    return Results.NotFound();
                }
                db.OrderItems.Remove(orderItemToDelete);
                db.SaveChanges();
                return Results.Ok("Item deleted");
            });
            // edit orderItem
            app.MapPut("/order-item/edit/{orderItemId}", (HhpwDbContext db, OrderItem orderItem, int orderItemId) =>
            {
                var orderItemToEdit = db.OrderItems.FirstOrDefault(x => x.Id == orderItemId);
                if (orderItemToEdit == null)
                {
                    return Results.NotFound();
                }

                orderItemToEdit.Notes = orderItem.Notes;

                db.SaveChanges();
                return Results.NoContent();
            });
            
        }
    }
}
