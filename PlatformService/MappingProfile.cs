using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Platform, PlatformDto>();

            CreateMap<PlatformForCreationDto, Platform>();
        }
    }
}
