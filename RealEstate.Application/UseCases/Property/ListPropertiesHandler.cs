using AutoMapper;
using RealEstate.Core.Contracts;
using RealEstate.Application.DTOs.Property;
using RealEstate.Application.Interfaces.Property;

namespace RealEstate.Application.UseCases.Property
{
    public class ListPropertiesHandler : IListPropertiesHandler
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public ListPropertiesHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyDto>> Handle(PropertyFilterDto filter, CancellationToken cancellationToken)
        {
            var properties = await _propertyRepository.GetAllAsync(
                name: filter.Name,
                minPrice: filter.MinPrice,
                maxPrice: filter.MaxPrice,
                year: filter.Year,
                cancellationToken: cancellationToken
            );

            if (!properties.Any())
                return new List<PropertyDto>();

            return _mapper.Map<List<PropertyDto>>(properties);
        }
    }
}
