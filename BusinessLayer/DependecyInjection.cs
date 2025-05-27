using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BusinessLayer
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
           services.AddValidatorsFromAssembly(typeof(DependecyInjection).Assembly);
           services.AddAutoMapper(typeof(DependecyInjection).Assembly);
           services.AddScoped<IDersService, DerslerService>();
            services.AddScoped<IMesajService, MesajService>();
            services.AddScoped<IOdaService, OdaService>();
            services.AddScoped<IFakulteService, FakulteService>();
            services.AddScoped<IBolumService,BolumService>();

            services.AddScoped<IKullaniciService, KullaniciService>();

            return services;
            
        }

       
    }
}
