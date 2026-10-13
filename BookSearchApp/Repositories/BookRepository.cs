using BookSearchApp.Models;

namespace BookSearchApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book(
                    1,
                    "Clean Code",
                    "A handbook of agile software craftsmanship",
                    new DateTime(2008, 8, 1)
                ),

                new Book(
                    2,
                    "The Pragmatic Programmer",
                    "Journey to mastery",
                    new DateTime(1999, 10, 20)
                ),

                new Book(
                    3,
                    "C# in Depth",
                    "Deep dive into C# language",
                    new DateTime(2019, 3, 23)
                )
            };
        }

        public Book? GetBookById(int id)
        {
            return GetBooks().FirstOrDefault(book => book.Id == id);
        }
    }
}