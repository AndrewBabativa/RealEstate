using FluentValidation;
using RealEstate.Common.Contracts.Property.Request;

namespace RealEstate.Application.Validators.Property
{
    public class CreatePropertyRequestValidator : AbstractValidator<CreatePropertyRequest>
    {
        public CreatePropertyRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede tener más de 200 caracteres.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("La dirección es obligatoria.")
                .MaximumLength(300).WithMessage("La dirección no puede tener más de 300 caracteres.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("El precio debe ser mayor que 0.");

            RuleFor(x => x.CodeInternal)
                .NotEmpty().WithMessage("El código interno es obligatorio.")
                .MaximumLength(50).WithMessage("El código interno no puede tener más de 50 caracteres.");

            RuleFor(x => x.Year)
                .GreaterThan(0).WithMessage("El año debe ser mayor que 0.")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("El año no puede ser mayor al año actual.");

            RuleFor(x => x.OwnerId)
                .GreaterThan(0).WithMessage("El ID del propietario debe ser mayor que 0.");
        }
    }
}