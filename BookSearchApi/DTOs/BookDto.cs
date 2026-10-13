namespace BookSearchApi.DTOs
{
    // The shape returned to API clients. Kept separate from the Book model
    // so the internal entity can change without breaking the API contract.
    public class BookDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime PublishedDate { get; set; }
    }
}
