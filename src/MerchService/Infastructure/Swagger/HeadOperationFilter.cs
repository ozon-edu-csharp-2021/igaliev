using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace MerchService.Infastructure.Swagger
{
    public class HeadOperationFilter
    {
        public class HeaderOperationFilter : IOperationFilter
        {
            public void Apply(OpenApiOperation operation, OperationFilterContext context)
            {
                operation.Parameters ??= new List<OpenApiParameter>();
                operation.Parameters.Add(new OpenApiParameter
                {
                    In = ParameterLocation.Header,
                    Name = "out-hearer",
                    Required = false,
                    Schema = new OpenApiSchema { Type = "string" }
                });
            }
        }
    }
}