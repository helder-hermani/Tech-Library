using FluentValidation.Results;
using Tech_Library_Api.Domain.Entities;
using Tech_Library_Api.Infrastructure;
using Tech_Library_Api.Security.Cryptography;
using Tech_Library_Api.Security.Tokens.Access;
using TechLibrary.communication.Requests;
using TechLibrary.communication.Responses;
using TechLibrary.Exceptions;

namespace Tech_Library_Api.UseCases.Users.Register
{
    public class RegisterUserUseCase
    {

        private readonly TechLibraryDbContext _db;

        public RegisterUserUseCase()
        {
            _db = new TechLibraryDbContext();
        }

        public ResponseRegisteredUserJson Execute(RequestUserJson request)
        {
            //Validação com Fluent Validation
            Validate(request);
            
            var entity = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = BCryptAlgorithm.HashPassword(request.Password)
            };

            _db.Users.Add(entity);
            _db.SaveChanges();

            var token = JwtTokenGenerator.GenerateToken(entity);

            //var db = new TechLibraryDbContext();
            //db.Users.Add(entity);
            //db.SaveChanges();

            return new ResponseRegisteredUserJson
                {
                    Name = entity.Name,
                    AccesToken = token
            };
        }

        private void Validate(RequestUserJson request)
        {
            var validation = new RegisterUserValidator();
            var result = validation.Validate(request);

            var existUserWithEmail = _db.Users.Any(record => record.Email.Equals(request.Email));

            if (existUserWithEmail)
            {
                result.Errors.Add(new ValidationFailure("Email", "E-mail já registrado na plataforma")); //"Email" é a propriedade de result em RegisterUserValidator, que receberá a mensagem de erro
            }

            if (!result.IsValid)
            {
                //Retorno de erro
                var erros = result.Errors.Select(erro => erro.ErrorMessage).ToList();
                throw new ErrorOnValidationException(erros);
            }
        }
    }
}
