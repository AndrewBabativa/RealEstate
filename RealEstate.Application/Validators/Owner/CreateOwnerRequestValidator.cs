using FluentValidation;
using RealEstate.Application.DTOs.Owner;

namespace RealEstate.Application.Validators.Owner
{
    public class CreateOwnerDtoValidator : AbstractValidator<CreateOwnerDto>
    {
        public CreateOwnerDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede tener más de 100 caracteres.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("La dirección es obligatoria.");

            RuleFor(x => x.Birthday)
                .LessThan(DateTime.Now).WithMessage("La fecha de nacimiento debe ser en el pasado.");

        }
    }
}