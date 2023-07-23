using DEPTAT.Application;
using DEPTAT.Persistence;
using OfficeOpenXml;

namespace DEPTAT.UI
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Add services to the container.
            //builder.Services.AddControllersWithViews();
            //builder.Services.ConfigurePersistenceServices(builder.Configuration);
            // Add services to the container.
            ConfigureServices(builder.Services, builder.Configuration); // Call the ConfigureServices method to register the persistence services

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            // Register your persistence services here
            services.ConfigurePersistenceServices(configuration);
            services.ConfigureApplicationServices();

            // Additional services can be registered here if needed
            services.AddControllersWithViews();
        }
    }
}