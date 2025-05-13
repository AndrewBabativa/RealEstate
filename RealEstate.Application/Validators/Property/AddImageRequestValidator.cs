using FluentValidation;
using RealEstate.Application.DTOs.PropertyImage;

namespace RealEstate.Application.Validators.Property
{
    public class PropertyImageDtoValidator : AbstractValidator<PropertyImageDto>
    {
        public PropertyImageDtoValidator()
        {
            RuleFor(x => x.PropertyId)
                .NotEmpty().WithMessage("El ID de la propiedad es obligatorio.");

            //RuleFor(x => x.Image)
            //    .NotNull().WithMessage("La imagen es obligatoria.")
            //    .Must(f => f.Length > 0).WithMessage("El archivo de imagen no puede estar vacío.");

        }
    }
}
