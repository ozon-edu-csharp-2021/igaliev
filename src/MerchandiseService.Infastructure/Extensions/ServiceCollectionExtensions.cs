
using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation;
using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.ManagerAggregation;
using MerchandiseService.Domain.MerchOrderAggregation;
using MerchandiseService.Infastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MerchandiseService.Infastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.addMed
            return services;
        }

        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMerchOrderRepository, MerchOrderRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            return services;
        }
    }


}