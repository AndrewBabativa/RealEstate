using AutoMapper;
using RealEstate.Core.Entities;
using RealEstate.Core.Contracts;
using RealEstate.Application.DTOs.Owner;
using RealEstate.Application.DTOs.Property;
using RealEstate.Application.Interfaces.Property;

namespace RealEstate.Application.UseCases.Property
{
    public class CreatePropertyHandler : ICreatePropertyHandler
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

        public async Task<PropertyDto> Handle(CreatePropertyDto dto, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetByIdAsync(dto.OwnerId)
                        ?? throw new KeyNotFoundException($"Owner with ID {dto.OwnerId} not found.");

            var property = _mapper.Map<PropertyEntity>(dto);
            await _propertyRepository.AddAsync(property);

            property.Owner = owner;

            var response = _mapper.Map<PropertyDto>(property);
            response.Owner = _mapper.Map<OwnerDto>(owner);

            return response;
        }

    }
}
