using System.Net;

namespace TechLibrary.Exceptions
{
    public abstract class TechLibraryException : SystemException
    {
        protected TechLibraryException(string message) : base(message) { } //base passa o parâmetro para o construtor da classe pai desta
            
        public abstract List<string> GetErrorsMessages();
        public abstract HttpStatusCode GetStatusCode();
    }
}
