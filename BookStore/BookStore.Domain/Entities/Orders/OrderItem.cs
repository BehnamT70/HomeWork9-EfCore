using BookStore.Domain.Common;
using BookStore.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities.Orders
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
