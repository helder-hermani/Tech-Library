using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TechLibrary.communication.Responses;
using TechLibrary.Exceptions;

namespace Tech_Library_Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is TechLibraryException TechLibraryException)
            {
                context.HttpContext.Response.StatusCode = (int)TechLibraryException.GetStatusCode();
                //context.HttpContext.Response.StatusCode = (int)((TechLibraryException)context.Exception).GetStatusCode();
                context.Result = new ObjectResult(new ResponseErrorMessageJson
                {
                    Errors = TechLibraryException.GetErrorsMessages()
                });
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Result = new ObjectResult(new ResponseErrorMessageJson
                {
                    Errors = ["Erro interno no servidor"]
                });
            }
        }
    }
}
