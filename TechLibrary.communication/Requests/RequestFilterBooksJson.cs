namespace TechLibrary.communication.Requests
{
    public class RequestFilterBooksJson
    {
        public int PageNumber { get; set; } = 0;
        public string? Title { get; set; } = string.Empty;
    }
}
