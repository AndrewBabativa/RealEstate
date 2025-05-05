using AutoMapper;
using RealEstate.Core.Entities;
using RealEstate.Core.Contracts;
using RealEstate.Common.Contracts.Owner.Responses;
using RealEstate.Common.Contracts.Property.Request;
using RealEstate.Common.Contracts.Property.Responses;

namespace RealEstate.Application.UseCases
{
    public class CreatePropertyHandler
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public CreatePropertyHandler(IPropertyRepository propertyRepository,
                                     IOwnerRepository ownerRepository,
                                     IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        public async Task<PropertyResponse> Handle(CreatePropertyRequest request, CancellationToken cancellationToken)
        {
            ValidateRequest(request);

            var owner = await _ownerRepository.GetByIdAsync(request.OwnerId)
                        ?? throw new KeyNotFoundException($"Owner with ID {request.OwnerId} not found.");

            var property = _mapper.Map<PropertyEntity>(request);
            await _propertyRepository.AddAsync(property);

            property.Owner = owner; 

            var response = _mapper.Map<PropertyResponse>(property);
            response.Owner = _mapper.Map<OwnerResponse>(owner);

            return response;
        }

        private void ValidateRequest(CreatePropertyRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request cannot be null");

            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Property name is required");

            if (string.IsNullOrWhiteSpace(request.Address))
                throw new ArgumentException("Property address is required");

            if (request.Price <= 0)
                throw new ArgumentException("Property price must be greater than zero");

            if (request.Year < 1900 || request.Year > DateTime.Now.Year)
                throw new ArgumentException("Invalid construction year");
        }
    }
}
