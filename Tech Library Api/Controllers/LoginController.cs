using Microsoft.AspNetCore.Mvc;
using Tech_Library_Api.UseCases.Login.DoLogin;
using TechLibrary.communication.Requests;
using TechLibrary.communication.Responses;
using TechLibrary.Exceptions;

namespace Tech_Library_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RequestLoginJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status401Unauthorized)]
        public IActionResult DoLogin(RequestLoginJson request)
        {
 
            var response = DoLoginUseCase.Execute(request);

            return Ok(response);
       
        }
    }
}
