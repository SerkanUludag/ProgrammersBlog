using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;
using ProgrammersBlog.Entity.Concrete;
using ProgrammersBlog.Entity.DTOs;
using ProgrammersBlog.Service.Abstract;
using ProgrammersBlog.Shared.Utilities.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammersBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IMailService _mailService;
        private readonly IToastNotification _toastNotification;
        private readonly IWritableOptions<AboutUsPageInfo> _aboutUsPageInfoWriter;      // edit appsetting.json without need of restarting app


        public HomeController(IArticleService articleService, IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo, IMailService mailService, IToastNotification toastNotification,
            IWritableOptions<AboutUsPageInfo> aboutUsPageInfoWriter)            // IOptionsSnapshot for getting value dynamicly from appsettings.json
        {
            _articleService = articleService;
            _aboutUsPageInfo = aboutUsPageInfo.Value;       // get values from appsetting.json object via configured AboutUsPageInfo class at startup.cs
            _mailService = mailService;
            _toastNotification = toastNotification;
            _aboutUsPageInfoWriter = aboutUsPageInfoWriter;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? categoryId, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            var articlesResult = await (categoryId == null
                ? _articleService.GetAllByPagingAsync(null, currentPage, pageSize, isAscending)
                : _articleService.GetAllByPagingAsync(categoryId.Value, currentPage, pageSize, isAscending));

            return View(articlesResult.Data);
        }

        [HttpGet]
        public IActionResult About()
        {

            return View(_aboutUsPageInfo);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(EmailSendDto emailSendDto)
        {
            if (ModelState.IsValid)
            {
                var result = _mailService.SendContactEmail(emailSendDto);       // no need to check result success status because if any error error page will return, configured MvcExceptionFilter
                _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                {
                    Title = "Successfull Operation!"
                });
                return View();
            }
            return View(emailSendDto);

        }
    }
}
