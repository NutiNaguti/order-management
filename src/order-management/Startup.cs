using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using order_management.common.Interfaces;
using order_management.repository;
using order_management.repository.Interfaces;
using order_management.services;

namespace order_management
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
            // конфигурация бд
            services.Configure<common.Common.OrderManagementDatabaseSettings>(
                Configuration.GetSection(nameof(common.Common.OrderManagementDatabaseSettings)));

            services.AddSingleton<common.Common.IOrderManagementDatabaseSettings>(x =>
                x.GetRequiredService<IOptions<common.Common.OrderManagementDatabaseSettings>>().Value);

            // сервисы
            services.AddScoped<IOrderManagementService, OrderManagementService>();
            services.AddScoped<IOrderContext, OrderContext>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
