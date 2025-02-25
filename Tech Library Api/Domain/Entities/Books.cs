namespace Tech_Library_Api.Domain.Entities
{
    public class Books
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Amount { get; set; } = 0;
    }
}
