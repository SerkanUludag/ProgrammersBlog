using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Core.Utilities.Extensions;
using ProgrammersBlog.Core.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Entity.DTOs;
using ProgrammersBlog.Service.Abstract;
using ProgrammersBlog.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgrammersBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllNonDeleted();
            
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CategoryAddPartial");
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Add(categoryAddDto, "Serkan");
                if(result.Status == ResultStatus.Success)
                {
                    var categoryAddAjaxModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel                            // serialize to JSON
                    {
                        CategoryDto = result.Data,
                        CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)          // to check modelState.isValid via hidden input element on front end, we added this extension
                    });

                    return Json(categoryAddAjaxModel);
                }
            }
            var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CategoryAddAjaxViewModel
            {
                CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto)          // to check modelState.isValid via hidden input element on front end 
            });
            return Json(categoryAddAjaxErrorModel);

        }

        [HttpGet]
        public async Task<IActionResult> Update(int categoryId)
        {
            var result = await _categoryService.GetCategoryUpdateDto(categoryId);

            if(result.Status == ResultStatus.Success)
            {
                return PartialView("_CategoryUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Update(categoryUpdateDto, "Serkan");
                if (result.Status == ResultStatus.Success)
                {
                    var categoryUpdateAjaxModel = JsonSerializer.Serialize(new CategoryUpdateAjaxViewModel                            // serialize to JSON
                    {
                        CategoryDto = result.Data,
                        CategoryUpdatePartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdateDto)          // to check modelState.isValid via hidden input element on front end, we added this extension
                    });

                    return Json(categoryUpdateAjaxModel);
                }
            }
            var categoryUpdateAjaxErrorModel = JsonSerializer.Serialize(new CategoryUpdateAjaxViewModel
            {
                CategoryUpdatePartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdateDto)          // to check modelState.isValid via hidden input element on front end 
            });
            return Json(categoryUpdateAjaxErrorModel);

        }



        public async Task<JsonResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllNonDeleted();
            var categories = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(categories);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int categoryId)
        {
            var result = await _categoryService.Delete(categoryId, "Serkan");

            var deletedCategory = JsonSerializer.Serialize(result.Data);
            return Json(deletedCategory);
        }
    }
}
