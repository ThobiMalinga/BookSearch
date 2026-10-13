using BookSearchApi.DTOs;
using BookSearchApi.Models;

namespace BookSearchApi.Mappers
{
    public static class BookMapper
    {
        // Entity -> DTO
        public static BookDto ToDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                PublishedDate = book.PublishedDate
            };
        }

        // Convenience for mapping a whole list
        public static List<BookDto> ToDtoList(this IEnumerable<Book> books)
        {
            return books.Select(book => book.ToDto()).ToList();
        }
    }
}
