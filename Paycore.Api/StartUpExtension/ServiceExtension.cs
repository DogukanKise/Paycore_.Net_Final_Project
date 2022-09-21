using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Paycore.Service;
using Paycore.Service.Mapper;
using Paycore.Service.Token.Abstract;
using Paycore.Service.Token.Concrete;

namespace Paycore.Api.StartUpExtension
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            // services 
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITokenService, TokenService>();
            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}
