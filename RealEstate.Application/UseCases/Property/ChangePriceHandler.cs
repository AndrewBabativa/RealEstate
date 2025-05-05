using AutoMapper;
using RealEstate.Common.Contracts.Property.Request;
using RealEstate.Common.Contracts.PropertyTrace.Request;
using RealEstate.Common.Contracts.Property.Responses;
using RealEstate.Core.Contracts;

namespace RealEstate.Application.UseCases
{
    public class ChangePriceHandler
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly CreatePropertyTraceHandler _traceHandler;
        private readonly IMapper _mapper;

        public ChangePriceHandler(IPropertyRepository propertyRepository,
                                  CreatePropertyTraceHandler traceHandler,
                                  IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _traceHandler = traceHandler;
            _mapper = mapper;
        }

        public async Task<PropertyResponse> Handle(ChangePriceRequest request, CancellationToken cancellationToken)
        {
            var property = await _propertyRepository.GetByIdAsync(request.PropertyId)
                           ?? throw new ArgumentException($"Property with ID {request.PropertyId} not found.");

            var oldPrice = property.Price;
            property.Price = request.NewPrice;

            await _propertyRepository.ChangePriceAsync(request.PropertyId, request.NewPrice);

            var traceRequest = new CreatePropertyTraceRequest
            {
                PropertyId = request.PropertyId,
                Name = $"Price changed from {oldPrice} to {request.NewPrice}",
                Value = request.NewPrice,
                Tax = 0,
                DateSale = DateTime.UtcNow
            };

            await _traceHandler.Handle(traceRequest);

            return _mapper.Map<PropertyResponse>(property);
        }
    }
}
