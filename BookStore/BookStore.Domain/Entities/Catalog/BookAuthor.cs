using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities.Catalog
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;
        public int AuthorId { get; set; }
        public Author Author { get; set; } =null!;
    }
}
