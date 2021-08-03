using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace order_management.Extensions
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionProvider _apiVersionProvider;

        public ConfigureSwaggerOptions(IApiVersionProvider apiVersionProvider) =>
            _apiVersionProvider = apiVersionProvider;
        
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var version in _apiVersionProvider.Versions)
            {
                options.SwaggerDoc(
                    version.GroupVersion.ToString(),
                    new OpenApiInfo()
                    {
                        Title = $"API {version.MajorVersion}",
                        Version = version.MajorVersion.ToString()
                    }
                );
            }
        }
    }
}