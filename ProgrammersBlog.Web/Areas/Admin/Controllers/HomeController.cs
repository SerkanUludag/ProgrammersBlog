using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammersBlog.Core.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Entity.Concrete;
using ProgrammersBlog.Service.Abstract;
using ProgrammersBlog.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]     // have to write this
    [Authorize(Roles = "Admin,Editor")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly UserManager<User> _userManager;
        public HomeController(ICategoryService categoryService, IArticleService articleService, 
                            ICommentService commentService, UserManager<User> userManager)
        {
            _categoryService = categoryService;
            _articleService = articleService;
            _commentService = commentService;
            _userManager = userManager;

        }
        public async Task<IActionResult> Index()
        {
            var categoriesCountResult = await _categoryService.CountByNonDeletedAsync();
            var articlesCountResult = await _articleService.CountByNonDeletedAsync();
            var commentsCountResult = await _commentService.CountByNonDeletedAsync();
            var articlesResult = await _articleService.GetAllAsync();
            var usersCount = await _userManager.Users.CountAsync();

            if(categoriesCountResult.Status == ResultStatus.Success
            && articlesCountResult.Status == ResultStatus.Success
            && commentsCountResult.Status == ResultStatus.Success
            && articlesResult.Status == ResultStatus.Success
            && usersCount > -1)
            {
                return View(new DashboardViewModel
                {
                    CategoriesCount = categoriesCountResult.Data,
                    ArticlesCount = articlesCountResult.Data,
                    CommentsCount = commentsCountResult.Data,
                    UserCount = usersCount,
                    Articles = articlesResult.Data
                });
            }

            return NotFound();
        }
    }
}
