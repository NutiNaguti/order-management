using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using order_management.common.Interfaces;
using order_management.Extensions;
using order_management.repository;
using order_management.repository.Interfaces;
using order_management.services.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace order_management
{
    public class Startup
    {
        private const string DevelopmentCORSRules = "localhost";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy(
                    DevelopmentCORSRules,
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            // конфигурация бд
            services.Configure<common.Common.OrderManagementDatabaseSettings>(
                Configuration.GetSection(nameof(common.Common.OrderManagementDatabaseSettings)));

            services.AddSingleton<common.Common.IOrderManagementDatabaseSettings>(x =>
                x.GetRequiredService<IOptions<common.Common.OrderManagementDatabaseSettings>>().Value);

            // сервисы
            services.AddScoped<IOrderManagementService, OrderManagementService>();
            services.AddScoped<IOrderContext, OrderContext>();

            services.AddControllers();
            services.AddApiVersioning();
            services.AddVersionedApiExplorer(opt => opt.GroupNameFormat = "'v'VVV");
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "web api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                "API v1"));
            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(DevelopmentCORSRules);
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
