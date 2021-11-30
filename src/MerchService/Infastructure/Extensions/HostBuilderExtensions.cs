
using MerchService.Infastructure.Filters;
using MerchService.Infastructure.Interceptors;
using MerchService.Infastructure.StartupFilter;
using MerchService.Infastructure.Swagger;
using MerchService.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MerchService.Infastructure.Extensions
{
    public static class HostBuilderExtension
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IMerchandiseService, Services.MerchandiseService>();
                services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();

                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MerchandiseService", Version = "v1" });
                    options.CustomSchemaIds(x => x.FullName);
                    options.OperationFilter<HeadOperationFilter.HeaderOperationFilter>();
                });
                services.AddControllers(options =>
                {
                    options.Filters.Add<GlobalExceptionFilter>();
                });
            });
            return builder;
        }
    }
}