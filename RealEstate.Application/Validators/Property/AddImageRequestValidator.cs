using FluentValidation;
using RealEstate.Common.Contracts.Auth.Request;
using RealEstate.Common.Contracts.PropertyImage.Request;

namespace RealEstate.Application.Validators.Property
{
    public class AddImageRequestValidator : AbstractValidator<AddImageRequest>
    {
        public AddImageRequestValidator()
        {
            RuleFor(x => x.PropertyId)
                .NotEmpty().WithMessage("El ID de la propiedad es obligatorio.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("La imagen es obligatoria.");

            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("El nombre del archivo es obligatorio.");
        }
    }
}
