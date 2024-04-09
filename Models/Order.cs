using System.ComponentModel.DataAnnotations;
namespace HHPWServer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? OrderType { get; set; }
        public bool OrderOpen { get; set; }
        public DateTime ClosedOne { get; set; }
        public int TipAmount { get; set; }
        public decimal OrderTotal { get; set; }
        public string? PaymentType { get; set; }
    }
}
