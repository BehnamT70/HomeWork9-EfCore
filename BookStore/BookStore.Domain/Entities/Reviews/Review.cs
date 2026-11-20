using BookStore.Domain.Common;
using BookStore.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities.Reviews
{
    public class Review : BaseEntity
    {
        public string UserId { get; set; } = null!;
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
