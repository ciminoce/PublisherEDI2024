namespace PublisherEDI2024.Domain
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly PublishedDate { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
