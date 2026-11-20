using BookStore.Domain.Common;
using BookStore.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities.Shopping
{
    public class CartItem : BaseEntity
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; } = null!;
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
