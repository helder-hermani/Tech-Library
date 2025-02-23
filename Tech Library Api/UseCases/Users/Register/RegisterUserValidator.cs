using FluentValidation;
using TechLibrary.communication.Requests;
namespace Tech_Library_Api.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(request => request.Email).EmailAddress().WithMessage("E-mail inválido");
            RuleFor(request => request.Password).NotEmpty().WithMessage("Senha é obrigatória");
            When(request => string.IsNullOrEmpty(request.Password) == false, () =>
            {
                RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(6).WithMessage("A senha deve possuir no mínimo 6 caracteres");
            });
        }
    }
}
