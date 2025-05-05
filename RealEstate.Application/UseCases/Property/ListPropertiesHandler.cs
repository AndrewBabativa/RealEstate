using AutoMapper;
using RealEstate.Core.Contracts;
using RealEstate.Common.Contracts.Property.Filters;
using RealEstate.Common.Contracts.Property.Responses;

namespace RealEstate.Application.UseCases
{
    public class ListPropertiesHandler
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public ListPropertiesHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyResponse>> Handle(PropertyFilter filter, CancellationToken cancellationToken)
        {
            var properties = await _propertyRepository.GetAllAsync(
                name: filter.Name,
                minPrice: filter.MinPrice,
                maxPrice: filter.MaxPrice,
                year: filter.Year,
                cancellationToken: cancellationToken
            );

            if (!properties.Any())
                return new List<PropertyResponse>();

            return _mapper.Map<List<PropertyResponse>>(properties);
        }
    }
}
