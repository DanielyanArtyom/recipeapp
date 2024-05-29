using AutoMapper;
using Recipe.Users.Business.Dtoes;
using Recipe.Users.Data.Entity;

namespace Recipe.Users.Business;

public class UsersAutoMapperProfile : Profile
{
    public UsersAutoMapperProfile()
    {
        CreateMap<User, UserDTO>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ReverseMap();
        
        CreateMap<User, UserRegistrationRequest>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ReverseMap();
    }
}