using System.Net;

namespace TechLibrary.Exceptions
{
    public abstract class TechLibraryException : System.Exception
    {
        public abstract List<string> GetErrorsMessages();
        public abstract HttpStatusCode GetStatusCode();
    }
}
