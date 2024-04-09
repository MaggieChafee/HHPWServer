using System.Reflection.Metadata.Ecma335;
using HHPWServer.Models;
using HHPWServer.DTOs;
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
                    return Results.NotFound();
                }
                return Results.Ok(singleOrder);
            });

            app.MapDelete("/orders/{id}", (HhpwDbContext db, int id) =>
            {
                var singleOrder = db.Orders.SingleOrDefault(o => o.Id == id);
                if (singleOrder == null)
                {
                    return Results.NotFound();
                }
                db.Orders.Remove(singleOrder);
                db.SaveChanges();
                return Results.Ok();
            });

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
        }
    }
}
