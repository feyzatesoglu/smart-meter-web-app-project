
using AutoMapper;
using SmartWebAppAPI.Entity.Dto.AuthDto;
using SmartWebAppAPI.Entity.Dto.Recommendation;
using SmartWebAppAPI.Entity.Models;

namespace SmartWebAppAPI.Infrastructure.Mapper
{
  public class MappingProfile : Profile
    {

       public MappingProfile() {

      CreateMap<User, RegisterDto>().ReverseMap();
      CreateMap<User, LoginDto>();
      CreateMap<RecommendationDto, Recommendation>().ReverseMap();

     
    }

  }
}
