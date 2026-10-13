using BookSearchApi.Models;

namespace BookSearchApi.Services
{
    public interface IBookService
    {
        // Business logic: search books by (partial, case-insensitive) name.
        List<Book> SearchBooksByName(string searchTerm);

        Book? GetBookById(int id);
    }
}
