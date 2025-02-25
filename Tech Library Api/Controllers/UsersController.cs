using Microsoft.AspNetCore.Mvc;
using Tech_Library_Api.UseCases.Users.Register;
using TechLibrary.communication.Requests;
using TechLibrary.communication.Responses;
using TechLibrary.Exceptions;

namespace Tech_Library_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("criar-usuario")]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status400BadRequest)]
        public IActionResult CreateUser(RequestUserJson request)
        {

            //try
            //{
                var useCase = new RegisterUserUseCase();
                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            //}
            //catch (TechLibraryException ex)
            //{
            //    var listaErros = new ResponseErrorMessageJson { Errors = ex.GetErrorsMessages() };
            //    return BadRequest(listaErros);
            //}
            //catch
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessageJson
            //        {
            //        Errors = ["Erro interno no servidor"]
            //    });
            //}

        }
    }
}
