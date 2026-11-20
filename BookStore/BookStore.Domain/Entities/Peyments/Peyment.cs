using BookStore.Domain.Common;
using BookStore.Domain.Entities.Orders;
using BookStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities.Peyments
{
    public class Payment : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public string? TransactionId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PaidAt { get; set; }
    }
}
