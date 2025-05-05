using AutoMapper;
using RealEstate.Common.Contracts.Property.Request;
using RealEstate.Common.Contracts.Property.Responses;
using RealEstate.Core.Contracts;

namespace RealEstate.Application.UseCases
{
    public class UpdatePropertyHandler
    {
        private readonly IPropertyRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePropertyHandler(IPropertyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PropertyResponse> Handle(UpdatePropertyRequest request, CancellationToken cancellationToken)
        {
            var property = await _repository.GetByIdAsync(request.PropertyId);

            if (property == null)
                throw new ArgumentException($"Property with ID {request.PropertyId} not found.");

            if (request.Name != null) property.Name = request.Name;
            if (request.Address != null) property.Address = request.Address;
            if (request.Year != null) property.Year = request.Year;

            await _repository.UpdateAsync(property);

            return _mapper.Map<PropertyResponse>(property);
        }
    }
}
