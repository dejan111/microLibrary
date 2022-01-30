using MicroLibrary.API.Mapping;
using MicroLibrary.Infrastructure.Context;
using MicroLibrary.Service.Interfaces;
using MicroLibrary.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace MicroLibrary.API.Extensions
{
    public static partial class ServiceCollectionExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments("MicroLibrary.API.xml");
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroLibrary.API", Version = "v1" });
            });

            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MicroLibraryContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")))
                .AddScoped<MicroLibraryContext>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<ILibraryUserService, LibraryUserService>();

            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            AutoMapper.MapperConfiguration mapperConfiguration = new(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            services.AddSingleton(mapperConfiguration.CreateMapper());

            return services;
        }

        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", 
                    builder =>
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            return services;
        }
    }
}
