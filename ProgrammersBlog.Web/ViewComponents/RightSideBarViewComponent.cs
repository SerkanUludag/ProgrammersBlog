using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Service.Abstract;
using ProgrammersBlog.Web.Models;
using System.Threading.Tasks;

namespace ProgrammersBlog.Web.ViewComponents
{
    public class RightSideBarViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        public RightSideBarViewComponent(ICategoryService categoryService, IArticleService articleService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriesResult = await _categoryService.GetAllNonDeletedAndActiveAsync();
            var articlesResult = await _articleService.GetAllByViewCountAsync(isAscending: false, takeSize: 5);

            return View(new RightSideBarViewModel
            {
                Categories = categoriesResult.Data.Categories,
                Articles = articlesResult.Data.Articles
            });
        }
    }
}
