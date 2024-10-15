using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OBilet.Application.Common.Behaviours;
using OBilet.Application.Common.Mappings;
using OBilet.Application.Services;
using OBilet.Application.Services.Configurations;
using System.Net.Http.Headers;
using System.Reflection;

namespace OBilet.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<OBiletConfiguration>(configuration.GetSection($"ServiceUrls:{OBiletConfiguration.ServiceName}"));
            serviceCollection.AddHttpClient<IOBiletService, OBiletService>(ConfigureClient);
            serviceCollection.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });
            MappingProfile.Map();

            return serviceCollection;
        }

        private static void ConfigureClient(IServiceProvider serviceProvider, HttpClient client)
        {
            var obiletConfiguration = serviceProvider.GetRequiredService<IOptions<OBiletConfiguration>>().Value;

            if (obiletConfiguration is null || string.IsNullOrEmpty(obiletConfiguration.BaseUrl))
            {
                throw new KeyNotFoundException("BaseUrl is not found");
            }

            client.BaseAddress = new Uri(obiletConfiguration.BaseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(obiletConfiguration.AuthenticationScheme, obiletConfiguration.Token);
        }
    }
}
