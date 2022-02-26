using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProgrammersBlog.Core.Entity.Concrete;
using System;
using System.Data.SqlTypes;

namespace ProgrammersBlog.Web.Filters
{
    public class MvcExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _environment;             // to get environment
        private readonly IModelMetadataProvider _metadataProvider;
        private readonly ILogger _logger;       // logger NLog
        public MvcExceptionFilter(IHostEnvironment environment, IModelMetadataProvider metadataProvider, ILogger<MvcExceptionFilter> logger)
        {
            _environment = environment;
            _metadataProvider = metadataProvider;
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            if (_environment.IsDevelopment())       // should be IsProduction() when published
            {
                context.ExceptionHandled = true;        // means we handle exception
                var mvcErrorModel = new MvcErrorModel();
                ViewResult result;
                switch (context.Exception)
                {
                    case SqlNullValueException:
                        mvcErrorModel.Message = "Sorry, there is an unexpected database error.";
                        mvcErrorModel.Detail = context.Exception.Message;                       // get exception message
                        result = new ViewResult { ViewName = "Error" };
                        result.StatusCode = 500;
                        _logger.LogError(context.Exception, context.Exception.Message);         // log
                        break;
                    case NullReferenceException:
                        mvcErrorModel.Message = "Sorry, there is an unexpected null value error.";
                        mvcErrorModel.Detail = context.Exception.Message;
                        result = new ViewResult { ViewName = "Error" };
                        result.StatusCode = 403;
                        _logger.LogError(context.Exception, context.Exception.Message);
                        break;
                    default:
                        mvcErrorModel.Message = "Sorry, there is an unexpected error.";
                        result = new ViewResult { ViewName = "Error" };
                        result.StatusCode = 500;        // internal server error
                        _logger.LogError(context.Exception, "custom log error message");
                        break;
                }

                // return View(model) manuel version
                result.ViewData = new ViewDataDictionary(_metadataProvider, context.ModelState);        // create ViewData
                result.ViewData.Add("MvcErrorModel", mvcErrorModel);            // add model to viewData
                context.Result = result;                    // set our result to return
            }
        }
    }
}
