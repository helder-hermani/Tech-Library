using Tech_Library_Api.Infrastructure;
using Tech_Library_Api.Security.Cryptography;
using Tech_Library_Api.Security.Tokens.Access;
using TechLibrary.communication.Requests;
using TechLibrary.communication.Responses;
using TechLibrary.Exceptions;

namespace Tech_Library_Api.UseCases.Login.DoLogin
{
    public class DoLoginUseCase
    {
        private static readonly TechLibraryDbContext _db;
        static DoLoginUseCase()
        {
            _db = new TechLibraryDbContext();
        }
        public static ResponseRegisteredUserJson Execute(RequestLoginJson request)
        {
            var user = _db.Users.FirstOrDefault(user => user.Email.Equals(request.Email)); //FirstOrDefault retorna o primeiro elemento que atende a condição ou null (apenas First retorna exceção se não encontrar)

            if (user is null)
            {
                throw new InvalidLoginException();
            }
            else
            {
                var isValidPassword = BCryptAlgorithm.VerifyPassword(request.Password, user.Password);

                if (!isValidPassword)
                {
                    throw new InvalidLoginException();
                }
      
                return new ResponseRegisteredUserJson
                {
                    Name = user.Name,
                    AccesToken = JwtTokenGenerator.GenerateToken(user),
                };

            }

                //return new ResponseRegisteredUserJson
                //{

                //};
        }
    }
}
