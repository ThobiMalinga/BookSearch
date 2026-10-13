using BookSearchApi.Models;

namespace BookSearchApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        // Mock / hard-coded data source (same as the Phase 1 console app).
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
