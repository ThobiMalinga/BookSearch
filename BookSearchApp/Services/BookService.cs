using BookSearchApp.Models;
using BookSearchApp.Repositories;

namespace BookSearchApp.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

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

            return _bookRepository
                .GetBooks()
                .Where(book => book.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public BookLookupResult GetBookById(string rawId)
        {
            if (string.IsNullOrWhiteSpace(rawId))
            {
                return new BookLookupResult
                {
                    Status = LookupStatus.InvalidInput,
                    Message = "You did not enter anything. Please enter a book ID."
                };
            }

            if (!int.TryParse(rawId, out int id))
            {
                return new BookLookupResult
                {
                    Status = LookupStatus.InvalidInput,
                    Message = "Invalid ID. Please enter a number."
                };
            }

            var book = _bookRepository.GetBookById(id);

            if (book is null)
            {
                return new BookLookupResult
                {
                    Status = LookupStatus.NotFound,
                    Message = "Book not found."
                };
            }

            return new BookLookupResult
            {
                Status = LookupStatus.Found,
                Book = book
            };
        }
    }
}
