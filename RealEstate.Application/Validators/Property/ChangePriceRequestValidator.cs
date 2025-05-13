using FluentValidation;
using RealEstate.Application.DTOs.Property;

namespace RealEstate.Application.Validators.Property
{
    public class ChangePriceDtoValidator : AbstractValidator<ChangePriceDto>
    {
        public ChangePriceDtoValidator()
        {
            RuleFor(x => x.PropertyId)
                .NotEmpty().WithMessage("El ID de la propiedad es obligatorio.");

            RuleFor(x => x.NewPrice)
                .GreaterThan(0).WithMessage("El nuevo precio debe ser mayor que 0.");
        }
    }
}
