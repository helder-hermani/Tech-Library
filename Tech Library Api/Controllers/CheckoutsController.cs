using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tech_Library_Api.Services.LoggedUser;
using Tech_Library_Api.UseCases.Checkouts;
using TechLibrary.communication.Responses;

namespace Tech_Library_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize] //Autorização requerida para todos endpoints do controller
    public class CheckoutsController : ControllerBase
    {
        [HttpPost]
        [Route("{bookId}")]
        //[Authorize] //Autorização requerida apenas para este endpoint
        [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult BookCheckout(Guid bookId)
        {
            var loggedUserService = new LoggedUserService(HttpContext);

            var useCase = new RegisterBookCheckoutsUseCase(loggedUserService);
            useCase.Execute(bookId);

            return Created();
        }
    }
}
