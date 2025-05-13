using AutoMapper;
using RealEstate.Application.DTOs.Property;
using RealEstate.Application.Interfaces.Property;
using RealEstate.Core.Contracts;

namespace RealEstate.Application.UseCases.Property
{
    public class UpdatePropertyHandler : IUpdatePropertyHandler
    {
        private readonly IPropertyRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePropertyHandler(IPropertyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PropertyDto> Handle(UpdatePropertyDto request, CancellationToken cancellationToken)
        {
            var property = await _repository.GetByIdAsync(request.PropertyId);

            if (property == null)
                throw new ArgumentException($"Property with ID {request.PropertyId} not found.");

            if (request.Name != null) property.Name = request.Name;
            if (request.Address != null) property.Address = request.Address;
            if (request.Year != null) property.Year = request.Year;

            await _repository.UpdateAsync(property);

            return _mapper.Map<PropertyDto>(property);
        }
    }
}
