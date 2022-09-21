using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Paycore.Api.StartUpExtension;
using Paycore.Base.Jwt;
using Paycore.Base.Util.Validators;

namespace Paycore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static JwtConfig JwtConfig { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            var connString = Configuration.GetConnectionString("PostgreSqlConnection");
            services.AddNHibernatePosgreSql(connString);

            services.AddServices();

            services.AddJwtBearerAuthentication();
            services.AddCustomizeSwagger();

            // Configure JWT Bearer JSON serialize
            JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));


            services.AddControllers().AddFluentValidation(f=>f.RegisterValidatorsFromAssemblyContaining<UserValidator>());
            services.AddControllers().AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<CategoryValidator>());
            services.AddControllers().AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<ProductValidator>());
            //services.AddControllers().AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<OfferValidator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Paycore Final Project v1"));
            }

            app.UseHttpsRedirection();

            // Auth Process
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
