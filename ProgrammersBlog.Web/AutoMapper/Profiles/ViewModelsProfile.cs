using AutoMapper;
using ProgrammersBlog.Entity.DTOs;
using ProgrammersBlog.Web.Areas.Admin.Models;

namespace ProgrammersBlog.Web.AutoMapper.Profiles
{
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<ArticleAddViewModel, ArticleAddDto>();
            CreateMap<ArticleUpdateDto, ArticleUpdateViewModel>().ReverseMap();     // vice versa
        }
    }
}
