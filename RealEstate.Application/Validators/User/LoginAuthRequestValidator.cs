using FluentValidation;
using RealEstate.Common.Contracts.Auth.Request;

namespace RealEstate.Application.Validators.Auth
{
    public class LoginAuthRequestValidator : AbstractValidator<LoginAuthRequest>
    {
        public LoginAuthRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre de usuario no debe exceder los 50 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contrase�a es obligatoria.")
                .MinimumLength(6).WithMessage("La contrase�a debe tener al menos 6 caracteres.");
        }
    }
}
