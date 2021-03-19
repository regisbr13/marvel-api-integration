using MarvelServiceIntegration.Application.Interfaces;
using MarvelServiceIntegration.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MarvelServiceIntegration.Api.Configurations
{
    public static class DependenceInjectionConfig
    {
        public static void AddDependenceInjectionConfig(this IServiceCollection services)
            => services.AddScoped<IComicsService, ComicsService>();
    }
}