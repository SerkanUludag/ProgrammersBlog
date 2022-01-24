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
        Task<IDataResult<CategoryDto>> GetAsync(int categoryId);
        /// <summary>
        /// Verilen ID parametresine ait kategorinin CategoryUpdateDto temsilini geriye döner
        /// </summary>
        /// <param name="categoryId">0'dan büyük integer ID değeri</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAllAsync();        // IList allowed because out T
        Task<IDataResult<CategoryListDto>> GetAllNonDeletedAsync();
        Task<IDataResult<CategoryListDto>> GetAllNonDeletedAndActiveAsync();
        /// <summary>
        /// Verilen CategoryAddDto ve CreatedByName parametrelerine ait bilgiler ile yeni bir kategori ekler
        /// </summary>
        /// <param name="categoryAddDto">categoryAddDto tipinde eklenecek kategori bilgileri</param>
        /// <param name="createdByName">string tipinde kullanıcı adı</param>
        /// <returns>Asenkron bir operasyon ile Task olarak bizlere ekleme işleminin sonucunu DataResult tipinde geri döner</returns>
        Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName);
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int categoryId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();

    }
}
