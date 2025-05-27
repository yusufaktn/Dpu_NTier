using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntiityLayer.Models;
using EntiityLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static  class DependecyInjection
    {


        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddIdentityCore<AppUser>(
                    
                
                
             ).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IUnitOfWork>(sv=>sv.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IBolumRepository, BolumRepository>();
            services.AddScoped<IDersNotuRepository,DersNotuRepository>();
            services.AddScoped<IDersRepository, DersRepository>();
            services.AddScoped<IFakulteRepository, FakulteRepository>();
            services.AddScoped<IOgretmenDerslerRepository, OgretmenDerslerRepository>();
            services.AddScoped<IOgretmenRepository, OgretmenRepository>();
            services.AddScoped<IUniversiteRepository, UniversiteRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOdaRepository, OdaRepository>();
            services.AddScoped<IOdaMesajlarıRepository,OdaMesajlarıRepository>();




            return services;
        }
    }
}
 