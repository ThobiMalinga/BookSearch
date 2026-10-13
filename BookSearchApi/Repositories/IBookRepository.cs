using BookSearchApi.Models;

namespace BookSearchApi.Repositories
{
    public interface IBookRepository
    {
        // LIST OF BOOKS
        List<Book> GetBooks();

        // GET A SINGLE BOOK BY ID
        Book? GetBookById(int id);
    }
}
