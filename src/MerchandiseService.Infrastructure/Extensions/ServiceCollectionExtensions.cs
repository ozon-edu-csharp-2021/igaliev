
using MediatR;
using MerchandiseService.Domain.MerchOrderAggregation;
using MerchandiseService.Infrastructure.Handlers.MerchOrder;
using MerchandiseService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MerchandiseService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateMerchOrderCommandHandler).Assembly);
            return services;
        }

        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMerchOrderRepository, MerchOrderRepository>();
            //  services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //    services.AddScoped<IManagerRepository, ManagerRepository>();
            return services;
        }
    }


}