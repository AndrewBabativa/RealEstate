using AutoMapper;
using RealEstate.Core.Entities;
using RealEstate.Core.Contracts;
using RealEstate.Application.DTOs.Owner;
using RealEstate.Application.Interfaces.Owner;

namespace RealEstate.Application.UseCases.Owner
{
    public class CreateOwnerHandler : ICreateOwnerHandler
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IDocumentStorageService _documentStorageService;
        private readonly IMapper _mapper;

        public CreateOwnerHandler(
            IOwnerRepository ownerRepository,
            IDocumentStorageService documentStorageService,
            IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _documentStorageService = documentStorageService;
            _mapper = mapper;
        }

        public async Task<OwnerDto> Handle(CreateOwnerDto ownerDto, CancellationToken cancellationToken)
        {
            string? photoUrl = null;

            if (ownerDto.PhotoFile != null)
            {
                photoUrl = await _documentStorageService.UploadImageAsync(ownerDto.PhotoFile);
            }

            var ownerEntity = _mapper.Map<OwnerEntity>(ownerDto);
            ownerEntity.Photo = photoUrl; 

            await _ownerRepository.AddAsync(ownerEntity);

            var response = _mapper.Map<OwnerDto>(ownerEntity);
            response.PhotoUrl = photoUrl; 

            return response;
        }
    }
}
