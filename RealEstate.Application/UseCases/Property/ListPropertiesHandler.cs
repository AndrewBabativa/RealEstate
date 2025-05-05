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
            var properties = await _propertyRepository.GetAllAsync(filter, cancellationToken);

            if (!properties.Any())
                throw new ArgumentException("No properties were found with the provided filter.");

            return _mapper.Map<List<PropertyResponse>>(properties);
        }
    }
}
