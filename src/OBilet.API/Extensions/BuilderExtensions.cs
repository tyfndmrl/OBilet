using OBilet.API.Filters;

namespace OBilet.API.Extensions
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SessionHeaderSwaggerFilter>();
            });

            return services;
        }
    }
}
