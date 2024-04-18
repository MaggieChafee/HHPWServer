using System.Reflection.Metadata.Ecma335;
using HHPWServer.Models;
using HHPWServer.DTOs;
using Microsoft.EntityFrameworkCore;
namespace HHPWServer.Controllers
{
    public class OrderApi
    {
        public static void Map(WebApplication app)
        {
            // all orders
            app.MapGet("/orders", (HhpwDbContext db) =>
            {
                if (db.Orders == null)
                {
                    return Results.BadRequest();
                }
                return Results.Ok(db.Orders);
            });
            // single order
            app.MapGet("/orders/{id}", (HhpwDbContext db, int id) =>
            {
                var singleOrder = db.Orders.SingleOrDefault(o => o.Id == id);
                if (singleOrder == null) 
                {
                    return Results.NotFound();
                }
                return Results.Ok(singleOrder);
            });
            // delete single order and all associated order items
            app.MapDelete("/orders/{id}", (HhpwDbContext db, int id) =>
            {
                var singleOrder = db.Orders.SingleOrDefault(x => x.Id == id);
                var orderItems = db.OrderItems.Where(x => x.OrderId == id).ToList();
                foreach(var item in orderItems)
                {
                    db.OrderItems.Remove(item);
                }
                if (singleOrder == null)
                {
                    return Results.NotFound();
                }
                db.Orders.Remove(singleOrder);
                db.SaveChanges();
                return Results.Ok();
            });
            // create an order
            app.MapPost("/orders", (HhpwDbContext db, CreateOrderDto dto) =>
            {
                var newOrder = new Order
                {
                    Name = dto.Name,
                    PhoneNumber = dto.PhoneNumber,
                    Email = dto.Email,
                    OrderType = dto.OrderType,
                    OrderOpen = true
                };
                db.Orders.Add(newOrder);
                db.SaveChanges();
                return Results.Created($"/orders/{newOrder.Id}", newOrder);
            });
            // update an order's customer information
            app.MapPut("/orders/{id}", (HhpwDbContext db, CreateOrderDto dto, int id) =>
            {
                var orderToUpdate = db.Orders.FirstOrDefault(x => x.Id == id);
                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }
                orderToUpdate.Name = dto.Name;
                orderToUpdate.PhoneNumber = dto.PhoneNumber;
                orderToUpdate.Email = dto.Email;
                orderToUpdate.OrderType = dto.OrderType;

                db.SaveChanges();
                return Results.NoContent();
            });
            // close an order
            app.MapPut("/orders/{id}/close-order", (HhpwDbContext db, int id, CloseOrderDto dto) =>
            {
                var orderToUpdate = db.Orders.FirstOrDefault(x => x.Id == id);
                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }
                var orderItems = db.OrderItems
                    .Where(x => x.OrderId == id)
                    .Sum(x => x.Item.ItemPrice);

                orderToUpdate.Id = id;
                orderToUpdate.OrderOpen = false;
                orderToUpdate.ClosedOn = DateTime.Now;
                orderToUpdate.TipAmount = dto.TipAmount;
                orderToUpdate.PaymentType = dto.PaymentType;
                orderToUpdate.OrderTotal = orderItems;

                db.SaveChanges();
                return Results.Ok("order closed");
            });

            // get order total 
            app.MapGet("/orders/{orderId}/order-total", (HhpwDbContext db, int orderId) =>
            {
                var items = db.OrderItems
                    .Where(x => x.OrderId == orderId)
                    .Sum(x => x.Item.ItemPrice);

                return Results.Ok(items);
            });   
        }
    }
}
