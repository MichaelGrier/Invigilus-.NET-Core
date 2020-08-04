
using Invigulus.Data.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Net;

namespace Invigulus.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InvigulusContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("InvigilusConnection")));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => opt.LoginPath="/Account/Login");
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStatusCodePages();

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseAuthentication();

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    OnPrepareResponse = ctx =>
            //    {
            //        if (ctx.Context.Request.Path.StartsWithSegments("/begin.html"))
            //        {
            //            ctx.Context.Response.Headers.Add("Cache-Control", "no-store");

            //            if (!ctx.Context.User.Identity.IsAuthenticated)
            //            {
            //                // respond HTTP 401 Unauthorized with empty body.
            //                ctx.Context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //                ctx.Context.Response.ContentLength = 0;
            //                ctx.Context.Response.Body = Stream.Null;

            //                // - or, redirect to another page. -
            //                ctx.Context.Response.Redirect("/Account/Login");
            //            }
            //        }
            //    }
            //});

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
