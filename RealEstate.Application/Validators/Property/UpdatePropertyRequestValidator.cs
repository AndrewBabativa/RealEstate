using FluentValidation;
using RealEstate.Common.Contracts.Property.Request;

public class UpdatePropertyRequestValidator : AbstractValidator<UpdatePropertyRequest>
{
    public UpdatePropertyRequestValidator()
    {
        RuleFor(x => x.PropertyId)
            .GreaterThan(0).WithMessage("El ID de la propiedad debe ser mayor que 0.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre de la propiedad es obligatorio.")
            .Length(3, 100).WithMessage("El nombre de la propiedad debe tener entre 3 y 100 caracteres.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("La dirección de la propiedad es obligatoria.")
            .Length(10, 200).WithMessage("La dirección debe tener entre 10 y 200 caracteres.");

        RuleFor(x => x.CodeInternal)
            .NotEmpty().WithMessage("El código interno de la propiedad es obligatorio.")
            .Matches("^[A-Za-z0-9]+$").WithMessage("El código interno solo puede contener letras y números.");

        RuleFor(x => x.Year)
            .GreaterThan(1900).WithMessage("El año debe ser mayor que 1900.")
            .LessThanOrEqualTo(DateTime.Now.Year).WithMessage($"El año no puede ser mayor al año actual ({DateTime.Now.Year}).");

        RuleFor(x => x.OwnerId)
            .GreaterThan(0).WithMessage("El ID del propietario debe ser mayor que 0.");
    }
}
