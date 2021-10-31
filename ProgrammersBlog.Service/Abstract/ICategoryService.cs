using ProgrammersBlog.Core.Utilities.Results.Abstract;
using ProgrammersBlog.Entity.Concrete;
using ProgrammersBlog.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Service.Abstract
{
    public interface ICategoryService   
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAll();        // IList allowed because out T
        Task<IDataResult<CategoryListDto>> GetAllNonDeleted();
        Task<IDataResult<CategoryListDto>> GetAllNonDeletedAndActive();
        Task<IResult> Add(CategoryAddDto categoryAddDto, string createdByName);
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> Delete(int categoryId, string modifiedByName);
        Task<IResult> HardDelete(int categoryId);

    }
}
