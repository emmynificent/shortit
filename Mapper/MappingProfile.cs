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
            CreateMap<OriginalUrl, ShortenUrlRequestDto>();
            CreateMap<ShortenUrlRequestDto, OriginalUrl>();
        }
    }
}
