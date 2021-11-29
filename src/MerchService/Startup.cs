using System.Reflection;
using FluentValidation;
using MediatR;
using MerchadiseSevice.Application.Common.Behaviors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MerchService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
    .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        
        }
    }
}