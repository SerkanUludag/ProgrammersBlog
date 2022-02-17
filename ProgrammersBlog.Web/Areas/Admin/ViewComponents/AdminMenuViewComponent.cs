using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using ProgrammersBlog.Entity.Concrete;
using ProgrammersBlog.Web.Areas.Admin.Models;
using System.Threading.Tasks;

namespace ProgrammersBlog.Web.Areas.Admin.ViewComponents
{
    public class AdminMenuViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public AdminMenuViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);          // get current user
            var roles = await _userManager.GetRolesAsync(user);
            if (user == null)
                return Content("User not found.");
            if (roles == null)
                return Content("Roles not found.");
            return View(new UserWithRolesViewModel
            {
                User = user,
                Roles = roles
            });
        }


    }
}
