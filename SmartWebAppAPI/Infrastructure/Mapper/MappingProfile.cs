
using AutoMapper;
using SmartWebAppAPI.Entity.Dto.AuthDto;
using SmartWebAppAPI.Entity.Dto.Recommendation;
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

      CreateMap<User, LoginDto>();
      CreateMap<RecommendationDto, Recommendation>().ReverseMap();

      CreateMap<UpdateDto, User>()
       .ForMember(dest => dest.UserType, opt => opt.Ignore())
       .ForMember(dest => dest.Role, opt => opt.Ignore())
       .ReverseMap();

    }

  }
}
