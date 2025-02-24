using Tech_Library_Api.Domain.Entities;
using Tech_Library_Api.Infrastructure;
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
            Validate(request);
            
            var entity = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            };

            var db = new TechLibraryDbContext();
            db.Users.Add(entity);
            db.SaveChanges();

            return new ResponseRegisteredUserJson
                {
                    Name = entity.Name,
                    AccesToken = ""
                };
        }

        private void Validate(RequestUserJson request)
        {
            var validation = new RegisterUserValidator();
            var result = validation.Validate(request);

            if (!result.IsValid)
            {
                //Retorno de erro
                var erros = result.Errors.Select(erro => erro.ErrorMessage).ToList();
                throw new ErrorOnValidationException(erros);
            }
        }
    }
}
