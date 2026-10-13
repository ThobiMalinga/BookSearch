using BookSearchApi.DTOs;
using BookSearchApi.Mappers;
using BookSearchApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookSearchApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        // Service injected via DI. The controller stays thin: it handles
        // HTTP concerns (status codes, DTO mapping) and delegates the
        // actual business logic to the service.
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET /api/books/search?name=clean
        [HttpGet("search")]
        public ActionResult<IEnumerable<BookDto>> SearchByName([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Please provide a book name to search for.");
            }

            var books = _bookService.SearchBooksByName(name);

            if (!books.Any())
            {
                return NotFound($"No books found matching '{name}'.");
            }

            return Ok(books.ToDtoList());
        }

        // GET /api/books/5
        [HttpGet("{id:int}")]
        public ActionResult<BookDto> GetById(int id)
        {
            var book = _bookService.GetBookById(id);

            if (book is null)
            {
                return NotFound($"No book found with id {id}.");
            }

            return Ok(book.ToDto());
        }
    }
}
