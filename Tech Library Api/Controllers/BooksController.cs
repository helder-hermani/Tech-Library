using Microsoft.AspNetCore.Mvc;
using Tech_Library_Api.UseCases.Books.Filter;
using TechLibrary.communication.Requests;
using TechLibrary.communication.Responses;

namespace Tech_Library_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("filter")]
        [ProducesResponseType(typeof(ResponseBooksJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        
        public IActionResult Filter(int pageNumber, string? title)
        {
            var useCase = new FilterBooksUseCase();

            var result = useCase.Execute(new RequestFilterBooksJson
            {
                PageNumber = pageNumber,
                Title = title
            });

            return Ok(result);

            //if (result.Books.Count > 0)
            //{
            //    return Ok(result);
            //}

            //return NoContent();
        }
    }
}
