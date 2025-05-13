using AutoMapper;
using RealEstate.Application.DTOs.PropertyImage;
using RealEstate.Application.Interfaces.Property;
using RealEstate.Core.Contracts;
using RealEstate.Core.Entities;

namespace RealEstate.Application.UseCases.Property
{
    public class AddImageToPropertyHandler : IAddImageToPropertyHandler
    {
        private readonly IDocumentStorageService _documentStorageService;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IPropertyImageRepository _propertyImageRepository;
        private readonly IMapper _mapper;

        public AddImageToPropertyHandler(
            IDocumentStorageService documentStorageService,
            IPropertyRepository propertyRepository,
            IPropertyImageRepository propertyImageRepository,
            IMapper mapper)
        {
            _documentStorageService = documentStorageService;
            _propertyRepository = propertyRepository;
            _propertyImageRepository = propertyImageRepository;
            _mapper = mapper;
        }

        public async Task Handle(PropertyImageDto request)
        {
            var property = await _propertyRepository.GetByIdAsync(request.PropertyId)
                              ?? throw new ArgumentException("Property not found.");

            var imageUrl = await _documentStorageService.UploadImageAsync(request.Image);
            var propertyImage = _mapper.Map<PropertyImageEntity>(request);
            propertyImage.PropertyId = property.PropertyId;
            propertyImage.Url = imageUrl;

            await _propertyImageRepository.AddAsync(propertyImage);
        }
    }
}
