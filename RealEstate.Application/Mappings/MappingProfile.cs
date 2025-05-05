using AutoMapper;
using RealEstate.Common.Contracts.Auth.Request;
using RealEstate.Common.Contracts.Owner.Request;
using RealEstate.Common.Contracts.Owner.Responses;
using RealEstate.Common.Contracts.Property.Request;
using RealEstate.Common.Contracts.Property.Responses;
using RealEstate.Common.Contracts.PropertyImage.Responses;
using RealEstate.Common.Contracts.PropertyTrace.Request;
using RealEstate.Common.Contracts.PropertyTrace.Responses;
using RealEstate.Core.Entities;

namespace RealEstate.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Requests -> Entities
            CreateMap<CreatePropertyRequest, PropertyEntity>()
                .ForMember(dest => dest.Owner, opt => opt.Ignore());

            CreateMap<AddImageRequest, PropertyImageEntity>()
                .ForMember(dest => dest.Url, opt => opt.Ignore())
                .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => true));

            CreateMap<CreatePropertyTraceRequest, PropertyTraceEntity>();
            CreateMap<CreateOwnerRequest, OwnerEntity>()
             .ForMember(dest => dest.Photo, opt => opt.Ignore());

            // Entities -> Responses
            CreateMap<PropertyEntity, PropertyResponse>();
            CreateMap<OwnerEntity, OwnerResponse>();
            CreateMap<PropertyImageEntity, PropertyImageResponse>();
            CreateMap<PropertyTraceEntity, PropertyTraceResponse>();
            CreateMap<OwnerEntity, OwnerResponse>();

        }
    }
}
