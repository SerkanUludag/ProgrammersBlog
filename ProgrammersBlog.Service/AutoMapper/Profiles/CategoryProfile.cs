using AutoMapper;
using ProgrammersBlog.Entity.Concrete;
using ProgrammersBlog.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Service.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>().ForMember(dest => dest.CreatedDate, options => options.MapFrom(x => DateTime.Now));
            CreateMap<CategoryUpdateDto, Category>().ForMember(dest => dest.ModifiedDate, options => options.MapFrom(x => DateTime.Now));
            CreateMap<Category, CategoryUpdateDto>();
        }
    }
}
