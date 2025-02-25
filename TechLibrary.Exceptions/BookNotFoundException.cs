using System.Net;

namespace TechLibrary.Exceptions
{
    public class BookNotFoundException : TechLibraryException
    {
        public BookNotFoundException(string message) : base(message) { }    //base passa o parâmetro para o construtor da classe pai desta

        public override List<string> GetErrorsMessages() => [Message];

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;

    }
}
