using BookSearchApp.Models;

namespace BookSearchApp.Services
{
    public interface IBookService
    {
        List<Book> SearchBooksByName(string searchTerm);

        BookLookupResult GetBookById(string rawId);
    }
}
