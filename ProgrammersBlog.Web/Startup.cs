using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgrammersBlog.Entity.Concrete;
using ProgrammersBlog.Service.AutoMapper.Profiles;
using ProgrammersBlog.Service.Extensions;
using ProgrammersBlog.Web.AutoMapper.Profiles;
using ProgrammersBlog.Web.Filters;
using ProgrammersBlog.Web.Helpers.Abstract;
using ProgrammersBlog.Web.Helpers.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProgrammersBlog.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }        // to get connection string from appsettings.json
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AboutUsPageInfo>(Configuration.GetSection("AboutUsPageInfo")); // map class with values on AboutUsPageInfo section from appsettings.json and give vith DI
            services.Configure<WebsiteInfo>(Configuration.GetSection("WebsiteInfo")); // 
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));         // email send with smtp server, get settings from appsetting.json
            services.AddControllersWithViews(options =>
            {
                //options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(value => "Bu alan boþ geçilmemelidir.");    hata mesajý türkçeleþtirme
                options.Filters.Add<MvcExceptionFilter>();        // custom exception filter middleware 
            }).AddRazorRuntimeCompilation().AddJsonOptions(opt =>       // mvc app with razor runtime and with json serializer options
            {
                // system.text.json not (external) newtonsoft.json library
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());      // const ajaxModel = jQuery.parseJSON(data)  => if(ajaxModel.ResultStatus === 0)
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;         // need for reference of nested json objects
            }).AddNToastNotifyToastr();                                                         // NToastNotify library

            services.AddSession();  //  like global variable
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile), typeof(UserProfile), typeof(ViewModelsProfile), typeof(CommentProfile));    // install automapper DI package
            services.LoadMyServices(connectionString: Configuration.GetConnectionString("localDB"));      // custom extension for our services. 
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(options =>          // cookie after identity
            {
                options.LoginPath = new PathString("/Admin/Auth/Login");
                options.LogoutPath = new PathString("/Admin/Auth/Logout");
                options.Cookie = new CookieBuilder
                {
                    Name = "ProgrammersBlog",
                    HttpOnly = true,                                        
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest         // must be CookieSecurePolicy.always for security
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7);       // cookie stays for 7 days
                options.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();       // returns status codes on errors, helpful for developer
            }
            app.UseSession();   // 
            app.UseStaticFiles(); // for static files

            app.UseRouting();

            app.UseAuthentication();        // kimlik doðrulama, routingden sonra gelmeli
            app.UseAuthorization();         // yetki
            app.UseNToastNotify();          // NToastNotify library
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(       // for admin area
                        name: "Admin",
                        areaName: "Admin",
                        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapDefaultControllerRoute();  // 
            });
        }
    }
}
