using Microsoft.OpenApi.Models;
using OBilet.API.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OBilet.API.Filters
{
    public class SessionHeaderSwaggerFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //NonSessionAttribute check
            var nonSessionAttribute = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<NonSessionAttribute>().FirstOrDefault() ??
                                      context.MethodInfo.GetCustomAttributes(true).OfType<NonSessionAttribute>().FirstOrDefault();

            if (nonSessionAttribute == null)
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "SessionId",
                    In = ParameterLocation.Header,
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }
                });

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "DeviceId",
                    In = ParameterLocation.Header,
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    }
                });
            }
        }
    }
}
