using TechLibrary.communication.Requests;
using TechLibrary.communication.Responses;
using TechLibrary.Exceptions;

namespace Tech_Library_Api.UseCases.Users.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {
            //Validação com Fluent Validation
            var validation = new RegisterUserValidator().Validate(request);

            if (validation.IsValid)
            {
                //Criação do usuário
                //Geração do token de acesso
                //Retorno do usuário criado
            }
            else
            {
                //Retorno de erro
                var erros = validation.Errors.Select(erro => erro.ErrorMessage).ToList();
                throw new ErrorOnValidationException(erros);
            }

            return new ResponseRegisteredUserJson
                {

                };
        }
    }
}
