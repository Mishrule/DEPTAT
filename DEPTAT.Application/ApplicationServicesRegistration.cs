using System;
using System.Reflection;
using DEPTAT.Application.Profiles;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DEPTAT.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
          // services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DeptatDbContext>().AddDefaultTokenProviders().AddDefaultUI();
            //services.AddIdentity()
            return services;
        }
    }
}
