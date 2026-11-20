using BookStore.Application.Interfaces.Repositories;
using BookStore.Domain.Entities.Catalog;
using BookStore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using BookStore.Application.Models;

namespace BookStore.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _context.Books
            .Include(x => x.Category)
            .Include(x => x.Publisher)
            .Include(x => x.BookAuthors)
                .ThenInclude(x => x.Author)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

  

    public async Task DeleteAsync(Book book)
    {
        _context.Books.Remove(book);
        await Task.CompletedTask;
    }

    public Task<Book?> GetByTitleAsync(string title)
    {
        throw new NotImplementedException();
    }

    public async Task<List<string>> GetAllBookTitlesAsync()
    {
        return await _context.Books
        .Select(book => book.Title)
        .ToListAsync();
    }

    public async Task<PagedResult<Book>> GetBooksPagedAsync(int pageNumber,int pageSize)
    {
        var query = _context.Books
            .AsNoTracking()
            .OrderBy(book => book.Id);

        var totalCount = await query.CountAsync();

        var books = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<Book>
        {
            Items = books,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }
}