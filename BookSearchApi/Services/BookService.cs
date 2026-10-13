using BookSearchApi.Models;
using BookSearchApi.Repositories;

namespace BookSearchApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        // Repository is injected via DI (registered in Program.cs).
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> SearchBooksByName(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return new List<Book>();
            }

            // LINQ search: partial, case-insensitive match on the name.
            return _bookRepository
                .GetBooks()
                .Where(book => book.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Book? GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }
    }
}
