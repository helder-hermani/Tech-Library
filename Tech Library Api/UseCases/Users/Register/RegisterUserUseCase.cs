using TechLibrary.communication.Requests;
using TechLibrary.communication.Responses;

namespace Tech_Library_Api.UseCases.Users.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {
            //Validação com Fluent Validation
            return new ResponseRegisteredUserJson
            {

            };
        }
    }
}
