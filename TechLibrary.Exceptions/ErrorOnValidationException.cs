using System.Net;

namespace TechLibrary.Exceptions
{
    public class ErrorOnValidationException : TechLibraryException
    {
        private readonly List<string> _errors;   //readonly indica que apenas o construtor pode alterar o valor da variável

        public ErrorOnValidationException(List<string> ErrorMessages) : base(string.Empty)
        {
            _errors = ErrorMessages;
        }
        public override List<string> GetErrorsMessages() => _errors;

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
    }
}
