using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgrammersBlog.Service.AutoMapper.Profiles;
using ProgrammersBlog.Service.Extensions;
using ProgrammersBlog.Web.AutoMapper.Profiles;
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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>       // mvc app with razor runtime and with json serializer options
            {
                // system.text.json not (external) newtonsoft.json library
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());      // const ajaxModel = jQuery.parseJSON(data)  => if(ajaxModel.ResultStatus === 0)
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;         // need for reference of nested json objects
            });
            services.AddSession();  //  like global variable
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile), typeof(UserProfile));    // install automapper DI package
            services.LoadMyServices();      // custom extension for our services. 
            services.ConfigureApplicationCookie(options =>          // cookie after identity
            {
                options.LoginPath = new PathString("/Admin/User/Login");
                options.LogoutPath = new PathString("/Admin/User/Logout");
                options.Cookie = new CookieBuilder
                {
                    Name = "ProgrammersBlog",
                    HttpOnly = true,                                        
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest         // must be CookieSecurePolicy.always for security
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7);       // cookie stays for 7 days
                options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied");
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(       // for admin area
                        name: "Admin",
                        areaName: "Admin",
                        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapDefaultControllerRoute();  // we write this
            });
        }
    }
}
