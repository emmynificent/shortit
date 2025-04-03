using AutoMapper;
using shortit.models;
using shortit.models.Dto;

namespace shortit.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OriginalUrl, shortenUrlResponseDto>();
            CreateMap<shortenUrlResponseDto, OriginalUrl>();
            CreateMap<shortenUrlRequestDto, OriginalUrl>();
            CreateMap<OriginalUrl, shortenUrlRequestDto>();
            CreateMap<string, shortenUrlResponseDto>()
            .ForMember(dest => dest.shortUrl,
            opt =>opt.MapFrom(src=> src));
           
        }
    }
}
