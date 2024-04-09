using Microsoft.EntityFrameworkCore;
using HHPWServer.Models;

namespace HHPWServer
{
    public class HhpwDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public HhpwDbContext(DbContextOptions<HhpwDbContext> context) : base(context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(new Item[] 
            { 
                new Item { Id = 1, ItemName = "Cheese Pizza", ItemPrice = 18.00M  },
                new Item { Id = 2, ItemName = "Pepeproni Pizza", ItemPrice = 20.00M },
                new Item { Id = 3, ItemName = "Buffalo Style Wings", ItemPrice = 15.00M },
                new Item { Id = 4, ItemName = "Garlic Knots", ItemPrice = 10.00M }
            });

            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { Id = 1, Name = "Maggie" }
            });

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order { Id = 1, Name = "Laura Epling", Email = "le@gmail.com", PhoneNumber = "615-555-5555", OrderOpen = true },
                new Order { Id = 2, Name = "Micaela Miller", Email = "mm@gmail.com", PhoneNumber = "615-555-5555", OrderOpen = true },
                new Order { Id = 3, Name = "Nik Lizcano", Email = "nl@gmail.com", PhoneNumber = "615-555-5555", OrderOpen = false },
                new Order { Id = 4, Name = "Jason Peterson", Email = "jp@gmail.com", PhoneNumber = "615-555-5555", OrderOpen = true }
            });

            modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
            {
                new PaymentType { Id = 1, Name = "Cash" },
                new PaymentType { Id = 2, Name = "Check" },
                new PaymentType { Id = 3, Name = "Debit" },
                new PaymentType { Id = 4, Name = "Credit" },
                new PaymentType { Id = 5, Name = "Mobile-Pay" }
            });

            modelBuilder.Entity<OrderType>().HasData(new OrderType[]
            {
                new OrderType { Id = 1, Name = "In-Person"},
                new OrderType { Id = 2, Name = "Phone"}
            });

            modelBuilder.Entity<OrderItem>().HasData(new OrderItem[]
            {
                new OrderItem { Id = 1, OrderId = 1, ItemId = 1},
                new OrderItem { Id = 2, OrderId = 1, ItemId = 2},
                new OrderItem { Id = 3, OrderId = 2, ItemId = 3}
            });
        }
    }
}
