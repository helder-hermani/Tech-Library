using Microsoft.AspNetCore.Mvc;
using Tech_Library_Api.UseCases.Users.Register;
using TechLibrary.communication.Requests;
using TechLibrary.communication.Responses;

namespace Tech_Library_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("criar-usuario")]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson),StatusCodes.Status201Created)]
        public IActionResult CreateUser(RequestUserJson request)
        {
            var useCase = new RegisterUserUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

    }
}
