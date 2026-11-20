using BookStore.Application.Interfaces.Repositories;
using BookStore.Domain.Entities.Catalog;
using BookStore.Application.Models;
namespace BookStore.Application.Services;

public class BookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task AddBookAsync(Book book)
    {
        var existingBook = await _bookRepository
            .GetByTitleAsync(book.Title);

        if (existingBook is not null)
        {
            existingBook.Stock += 1;
        }
        else
        {
            book.Stock = 1;

            await _bookRepository.AddAsync(book);
        }

        await _bookRepository.SaveChangesAsync();
    }
    public async Task<bool> UpdateBookAsync(Book book)
    {
        var existingBook = await _bookRepository
            .GetByIdAsync(book.Id);

        if (existingBook is null)
        {
            return false;
        }

        existingBook.Title = book.Title;
        existingBook.ISBN = book.ISBN;
        existingBook.Description = book.Description;
        existingBook.Price = book.Price;
        existingBook.CategoryId = book.CategoryId;
        existingBook.PublisherId = book.PublisherId;
        existingBook.PublishedDate = book.PublishedDate;
        existingBook.ImageUrl = book.ImageUrl;

        await _bookRepository.SaveChangesAsync();

        return true;
    }
    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _bookRepository.GetByIdAsync(id);
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book is null)
        {
            return false;
        }

        await _bookRepository.DeleteAsync(book);

        await _bookRepository.SaveChangesAsync();

        return true;
    }
    public async Task<List<string>> GetAllBookTitlesAsync()
    {
        return await _bookRepository.GetAllBookTitlesAsync();
    }
    public async Task<PagedResult<Book>> GetBooksPagedAsync(int pageNumber,int pageSize)
    {
        if (pageNumber < 1)
        {
            pageNumber = 1;
        }

        if (pageSize < 1)
        {
            pageSize = 10;
        }

        return await _bookRepository.GetBooksPagedAsync(
            pageNumber,
            pageSize);
    }
}