using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]     // have to write this
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
