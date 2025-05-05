using RealEstate.Core.Entities;
using RealEstate.Core.Contracts;
using RealEstate.Common.Contracts.Owner.Request;
using RealEstate.Common.Contracts.Owner.Responses;

namespace RealEstate.Application.UseCases
{
    public class CreateOwnerHandler
    {
        private readonly IOwnerRepository _ownerRepository;

        public CreateOwnerHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<OwnerResponse> Handle(CreateOwnerRequest request, CancellationToken cancellationToken)
        {
            var owner = new OwnerEntity
            {
                Name = request.Name,
                Address = request.Address,
                Photo = request.Photo,
                Birthday = request.Birthday
            };

            await _ownerRepository.AddAsync(owner);

            return new OwnerResponse
            {
                OwnerId = owner.OwnerId,
                Name = owner.Name,
                Address = owner.Address,
                Photo = owner.Photo,
                Birthday = owner.Birthday
            };
        }
    }
}
