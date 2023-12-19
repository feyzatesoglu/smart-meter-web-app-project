
using AutoMapper;
using SmartWebAppAPI.Entity.Dto;
using SmartWebAppAPI.Entity.Models;

namespace SmartWebAppAPI.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {

       public MappingProfile() {

      CreateMap<RegisterDto, User>()
       .ForMember(dest => dest.UserType, opt => opt.Ignore())
       .ForMember(dest => dest.Role, opt => opt.Ignore())
       .ReverseMap();



    }

  }
}
