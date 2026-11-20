using BookStore.Domain.Common;
using BookStore.Domain.Entities.Customer;
using BookStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities.Orders
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public string RecipientName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string? AddressDescription { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
