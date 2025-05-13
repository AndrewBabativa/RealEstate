using AutoMapper;
using RealEstate.Application.DTOs.Owner;
using RealEstate.Application.DTOs.Property;
using RealEstate.Application.DTOs.PropertyImage;
using RealEstate.Application.DTOs.PropertyTrace;
using RealEstate.Core.Entities;

namespace RealEstate.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOwnerDto, OwnerEntity>()
                .ForMember(dest => dest.Photo, opt => opt.Ignore())
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.PhotoFile != null ? "/images/" + src.PhotoFile.FileName : null));

            CreateMap<CreatePropertyDto, PropertyEntity>()
                .ForMember(dest => dest.Owner, opt => opt.Ignore());

            CreateMap<ChangePriceDto, PropertyEntity>();
            CreateMap<UpdatePropertyDto, PropertyEntity>();
            CreateMap<CreatePropertyTraceDto, PropertyTraceEntity>();

            CreateMap<OwnerEntity, OwnerDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photo));  

            CreateMap<PropertyEntity, PropertyDto>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));

            CreateMap<PropertyImageEntity, PropertyImageDto>()
                .ForMember(dest => dest.ImageId, opt => opt.MapFrom(src => src.PropertyImageId));

            CreateMap<PropertyImageDto, PropertyImageEntity>()
                .ForMember(dest => dest.PropertyImageId, opt => opt.MapFrom(src => src.ImageId))
                .ForMember(dest => dest.Url, opt => opt.Ignore()) 
                .ForMember(dest => dest.Property, opt => opt.Ignore());

            CreateMap<PropertyTraceEntity, PropertyTraceDto>();
        }
    }
}
