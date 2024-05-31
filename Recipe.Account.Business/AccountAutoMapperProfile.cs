using AutoMapper;
using Recipe.Account.Business.Dtoes;
using Recipe.Account.Data.Entity;

namespace Recipe.Account.Business
{
    public class AccountAutoMapperProfile : Profile
    {
        public AccountAutoMapperProfile()
        {
            CreateMap<AccountEntity, AccountDTO>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
           .ReverseMap();
        }
    }
}
