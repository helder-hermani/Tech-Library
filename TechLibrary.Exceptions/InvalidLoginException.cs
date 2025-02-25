using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Exceptions
{
    public class InvalidLoginException : TechLibraryException
    {
        public InvalidLoginException() : base("E-mail ou senha inválidos") { }
        public override List<string> GetErrorsMessages() => [Message];

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;

    }
}
