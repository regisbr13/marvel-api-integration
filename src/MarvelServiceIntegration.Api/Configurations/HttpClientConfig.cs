using MarvelServiceIntegration.Application.Dtos;
using MarvelServiceIntegration.Application.Interfaces;
using MarvelServiceIntegration.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace MarvelServiceIntegration.Api.Configurations
{
    public static class HttpClientConfig
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            var settingsSection = configuration.GetSection("MarvelComicsApiSettings");
            var marvelApiSettings = settingsSection.Get<MarvelComicsApiSettings>();
            services.Configure<MarvelComicsApiSettings>(settingsSection);
            services.AddSingleton(x => x.GetRequiredService<IOptions<MarvelComicsApiSettings>>().Value);
            services.AddHttpClient<IMarvelApiService, MarvelApiService>
                (opt => opt.BaseAddress = new Uri(marvelApiSettings.BaseUrl));
        }
    }
}