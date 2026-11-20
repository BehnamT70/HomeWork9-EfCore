using BookStore.Domain.Entities.Catalog;
using BookStore.Application.Models;
namespace BookStore.Application.Interfaces.Repositories;

public interface IBookRepository
{
    Task<Book?> GetByTitleAsync(string title);
    Task<Book?> GetByIdAsync(int id);
    Task AddAsync(Book book);
    Task DeleteAsync(Book book);
    Task<List<string>> GetAllBookTitlesAsync();
    Task<PagedResult<Book>> GetBooksPagedAsync(int pageNumber,int pageSize);
    Task SaveChangesAsync();
}