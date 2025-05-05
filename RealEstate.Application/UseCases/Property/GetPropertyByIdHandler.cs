using AutoMapper;
using RealEstate.Common.Contracts.Property.Responses;
using RealEstate.Core.Contracts;

namespace RealEstate.Application.UseCases
{
    public class GetPropertyByIdHandler
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public GetPropertyByIdHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<PropertyResponse> Handle(int id, CancellationToken cancellationToken = default)
        {
            var property = await _propertyRepository.GetByIdAsync(id);

            if (property == null)
                throw new KeyNotFoundException($"Property with ID {id} not found.");

            return _mapper.Map<PropertyResponse>(property);
        }
    }
}
