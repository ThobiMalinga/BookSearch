namespace BookSearchApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime PublishedDate { get; set; }

        public Book(int id, string name, string description, DateTime publishedDate)
        {
            Id = id;
            Name = name;
            Description = description;
            PublishedDate = publishedDate;
        }
    }
}
