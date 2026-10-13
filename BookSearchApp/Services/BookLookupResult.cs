using BookSearchApp.Models;

namespace BookSearchApp.Services
{
    public enum LookupStatus
    {
        Found,
        NotFound,
        InvalidInput,
        Error
    }

    public class BookLookupResult
    {
        public LookupStatus Status { get; set; }

        public Book? Book { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
