using FluentValidation;
using RealEstate.Application.DTOs.Auth;

namespace RealEstate.Application.Validators.Auth
{
    public class RegisterAuthDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterAuthDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre de usuario no debe exceder los 50 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.");

        }
    }
}
