using Domain.Entities;
using Domain.DTOs;
using Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<Book> GetBookByIdAsync(int id) => _bookRepository.GetBookByIdAsync(id);

        public Task<IEnumerable<Book>> GetAllBooksAsync() => _bookRepository.GetAllBooksAsync();

        public Task AddBookAsync(BookDto dto)
        {
            var book = new Book { Title = dto.Title, Author = dto.Author, ISBN = dto.ISBN };
            return _bookRepository.AddBookAsync(book);
        }

        public async Task UpdateBookAsync(int id, BookDto dto)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null) throw new KeyNotFoundException("Book not found");

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.ISBN = dto.ISBN;
            await _bookRepository.UpdateBookAsync(book);
        }

        public Task DeleteBookAsync(int id) => _bookRepository.DeleteBookAsync(id);
    }
}
