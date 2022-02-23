using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.Core.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Entity.ComplexTypes;
using ProgrammersBlog.Service.Abstract;
using ProgrammersBlog.Web.Models;
using System;
using System.Threading.Tasks;

namespace ProgrammersBlog.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            var searchResult = await _articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);
            if(searchResult.Status == ResultStatus.Success)
            {
                return View(new ArticleSearchViewModel
                {
                    ArticleListDto = searchResult.Data,
                    Keyword = keyword
                });
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int articleId)
        {
            var articleResult = await _articleService.GetAsync(articleId);
            if(articleResult.Status == ResultStatus.Success)
            {
                var userArticles = await _articleService.GetAllByUserIdOnFilter(articleResult.Data.Article.UserId, FilterBy.Category, OrderBy.Date,
                    false, 10, articleResult.Data.Article.CategoryId, DateTime.Now, DateTime.Now, 0, 99999, 0, 99999);
                await _articleService.IncreaseViewCountAsync(articleId);
                return View(new ArticleDetailViewModel
                {
                    ArticleDto = articleResult.Data,
                    ArticleDetailRightSideBarViewModel = new ArticleDetailRightSideBarViewModel
                    {
                        ArticleListDto = userArticles.Data,
                        Header = "User's other articles on this category",
                        User = articleResult.Data.Article.User
                    }
                });
            }
            return NotFound();
        }
    }
}
