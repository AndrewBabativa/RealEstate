using FluentValidation;
using RealEstate.Common.Contracts.Property.Request;

namespace RealEstate.Application.Validators.Property
{
    public class ChangePriceRequestValidator : AbstractValidator<ChangePriceRequest>
    {
        public ChangePriceRequestValidator()
        {
            RuleFor(x => x.PropertyId)
                .NotEmpty().WithMessage("El ID de la propiedad es obligatorio.");

            RuleFor(x => x.NewPrice)
                .GreaterThan(0).WithMessage("El nuevo precio debe ser mayor que 0.");
        }
    }
}
