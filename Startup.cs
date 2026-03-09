using BlazorStore.Areas.Identity;
using BlazorStore.Data;
using BlazorStore.Models;
using BlazorStore.Services;
using BlazorStore.Ultilities;
using Majorsoft.Blazor.Components.Common.JsInterop;
using Majorsoft.Blazor.Components.CssEvents;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Radzen;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BlazorStore
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
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(
                   DataManage.GetConnectionString(Configuration)),ServiceLifetime.Transient);
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddIdentity<CustomUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddDefaultUI()
             .AddDefaultTokenProviders()
             .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages().AddRazorRuntimeCompilation(); ;
            services.AddServerSideBlazor();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<CustomUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped(sp => sp.GetRequiredService<IHttpContextAccessor>().HttpContext);
            services.AddScoped<IUserDetector, UserDetector>();
            services.AddScoped<ISlugService, SlugService>();
            services.AddScoped<ICanUserComment, CanUserComment>();
            services.AddScoped<IImageService, ImageService>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddScoped<IEmailSender, EmailService>();
            services.AddScoped<AllItemStateModel>();
            services.AddMvc();
            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();
            services.AddCssEvents();
            services.AddJsInteropExtensions();
            services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StripeConfiguration.ApiKey = "";
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });          
        }
    }
}
