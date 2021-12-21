using AutoMapper;
using ProgrammersBlog.Core.Utilities.Results.Abstract;
using ProgrammersBlog.Core.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Core.Utilities.Results.Concrete;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Entity.Concrete;
using ProgrammersBlog.Entity.DTOs;
using ProgrammersBlog.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Service.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            var addedCategory = await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryAddDto.Name} has been successfully added.", new CategoryDto 
            {
                Category = addedCategory,
                Status = ResultStatus.Success,
                Message = $"{categoryAddDto.Name} has been successfully added."
            });
        }

        public async Task<IDataResult<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var oldCategory = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
            var category = _mapper.Map<CategoryUpdateDto,Category>(categoryUpdateDto, oldCategory);
            category.ModifiedByName = modifiedByName;
            var updatedCategory = await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, $"{categoryUpdateDto.Name} has been successfully updated.", new CategoryDto 
            {
                Category = updatedCategory,
                Status = ResultStatus.Success,
                Message = $"{categoryUpdateDto.Name} has been successfully updated."
            });
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == categoryId, x => x.Articles);
            if(category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto 
                {
                    Category = category,
                    Status = ResultStatus.Success
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Category not found.", new CategoryDto 
            {
                Category = null,
                Status = ResultStatus.Error,
                Message = "Category not found."
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, x => x.Articles);
            if(categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto 
                {
                    Categories = categories,
                    Status = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "No category found.", new CategoryListDto 
            {
                Categories = null,
                Status = ResultStatus.Error,
                Message = "No category found."
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllNonDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x => !x.IsDeleted, x => x.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    Status = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "No category found.", new CategoryListDto
            {
                Categories = null,
                Status = ResultStatus.Error,
                Message = "No category found."
            });
        }

        public async Task<IDataResult<CategoryListDto>> GetAllNonDeletedAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(x => !x.IsDeleted && x.IsActive, x => x.Articles);
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    Status = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "No category found.", null);
        }

        public async Task<IDataResult<CategoryDto>> Delete(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == categoryId);
            if(category != null)
            {
                category.IsDeleted = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                var deletedCategory = await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, $"{deletedCategory.Name} has been successfully deleted.", new CategoryDto
                {
                    Category = deletedCategory,
                    Status = ResultStatus.Success,
                    Message = $"{deletedCategory.Name} has been successfully deleted."
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, "Category not found.", new CategoryDto
            {
                Category = null,
                Status = ResultStatus.Error,
                Message = "Category not found."
            });
        }

        public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(x => x.Id == categoryId);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{category.Name} has been successfully deleted from database.");
            }
            return new Result(ResultStatus.Error, "Category not found.");
        }

        public async Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDto(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAsync(c => c.Id == categoryId);

            if (result)
            {
                var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
                var categoryUpdateDto = _mapper.Map<CategoryUpdateDto>(category);
                return new DataResult<CategoryUpdateDto>(ResultStatus.Success, categoryUpdateDto);
            }
            else
            {
                return new DataResult<CategoryUpdateDto>(ResultStatus.Error, message: "Category not found", data: null);
            }
        }
    }
}
