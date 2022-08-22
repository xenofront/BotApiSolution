using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BotApi.Interfaces;
using BotApi.Commands;
using System;
using System.Net.Http.Headers;

namespace BotApi
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
            services.AddControllers();
            // services.AddControllers().AddNewtonsoftJson();

            services.AddSingleton<ICommandFactory, CommandFactory>();
            services.AddHttpClient("webHotelier", c =>
            {
                c.BaseAddress = new Uri(Configuration.GetValue<string>("WebHotelierApi:Uri"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Configuration.GetValue<string>("WebHotelierApi:Secret"));
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            
            services.AddControllersWithViews();
            services.AddRazorPages();
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
            
            app.UseRouting();

            //app.UseAuthentication();
           // app.UseAuthorization();


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints => {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute("default", "{controller=Hotel}/{action=Index}/{id?}");
            });
        }
    }
}
