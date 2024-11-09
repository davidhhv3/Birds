using _2.BirdsDomain.CustomEntities;
using _2.BirdsDomain.Interfaces;
using _3.BirdsApplication.Services;
using _4.BirdsInfrastructure.Data;
using _4.BirdsInfrastructure.Interfaces;
using _4.BirdsInfrastructure.Options;
using _4.BirdsInfrastructure.Repositories;
using _4.BirdsInfrastructure.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _4.BirdsInfrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));
            return services;
        }

        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BirdsContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Connection"))
           );
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));           
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
        public static IApplicationBuilder UseSwaggerWithUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
