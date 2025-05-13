using AutoMapper;
using RealEstate.Application.DTOs.Property;
using RealEstate.Core.Contracts;
using RealEstate.Application.DTOs.PropertyTrace;
using RealEstate.Application.Interfaces.Property;

namespace RealEstate.Application.UseCases.Property
{
    public class ChangePriceHandler : IChangePriceHandler
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly ICreatePropertyTraceHandler _traceHandler;
        private readonly IMapper _mapper;

        public ChangePriceHandler(IPropertyRepository propertyRepository,
                                  ICreatePropertyTraceHandler traceHandler,
                                  IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _traceHandler = traceHandler;
            _mapper = mapper;
        }

        public async Task<PropertyDto> Handle(ChangePriceDto dto, CancellationToken cancellationToken)
        {
            var property = await _propertyRepository.GetByIdAsync(dto.PropertyId)
                           ?? throw new ArgumentException($"Property with ID {dto.PropertyId} not found.");

            var oldPrice = property.Price;
            property.Price = dto.NewPrice;

            await _propertyRepository.ChangePriceAsync(dto.PropertyId, dto.NewPrice);

            var traceRequest = new CreatePropertyTraceDto
            {
                PropertyId = dto.PropertyId,
                Name = $"Price changed from {oldPrice} to {dto.NewPrice}",
                Value = dto.NewPrice,
                Tax = 0,
                DateSale = DateTime.UtcNow
            };

            await _traceHandler.Handle(traceRequest);

            return _mapper.Map<PropertyDto>(property);
        }
    }
}
