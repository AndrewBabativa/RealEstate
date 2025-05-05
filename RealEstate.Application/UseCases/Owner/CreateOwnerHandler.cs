using AutoMapper;
using RealEstate.Core.Entities;
using RealEstate.Core.Contracts;
using RealEstate.Common.Contracts.Owner.Request;
using RealEstate.Common.Contracts.Owner.Responses;

namespace RealEstate.Application.UseCases
{
    public class CreateOwnerHandler
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

        public async Task<OwnerResponse> Handle(CreateOwnerRequest request, CancellationToken cancellationToken)
        {
            string? photoUrl = null;

            if (request.Photo != null)
            {
                photoUrl = await _documentStorageService.UploadImageAsync(request.Photo);
            }

            var owner = _mapper.Map<OwnerEntity>(request);
            owner.Photo = photoUrl;
            await _ownerRepository.AddAsync(owner);
            var response = _mapper.Map<OwnerResponse>(owner);

            return response;
        }
    }
}
