using AutoMapper;
using RealEstate.Application.DTOs.Property;
using RealEstate.Application.Interfaces.Property;
using RealEstate.Core.Contracts;

namespace RealEstate.Application.UseCases.Property
{
    public class GetPropertyByIdHandler : IGetPropertyByIdHandler
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public GetPropertyByIdHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<PropertyDto> Handle(int id, CancellationToken cancellationToken = default)
        {
            var property = await _propertyRepository.GetByIdAsync(id);

            if (property == null)
                throw new KeyNotFoundException($"Property with ID {id} not found.");

            return _mapper.Map<PropertyDto>(property);
        }
    }
}
