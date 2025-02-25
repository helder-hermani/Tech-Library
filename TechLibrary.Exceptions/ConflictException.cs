using System.Net;

namespace TechLibrary.Exceptions
{
    public class ConflictException(string message) : TechLibraryException(message)
    {
        public override List<string> GetErrorsMessages() => [Message];

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Conflict;

    }
}
