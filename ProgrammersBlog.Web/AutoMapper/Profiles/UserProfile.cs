using AutoMapper;
using ProgrammersBlog.Entity.Concrete;
using ProgrammersBlog.Entity.DTOs;

namespace ProgrammersBlog.Web.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
