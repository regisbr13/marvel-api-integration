using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace MarvelServiceIntegration.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Marvel Integration Service Api",
                    Version = "v1",
                    Description = "<h4>A simple web application to get the comics with a Character from Marvel Comics Api.<br>" +
                    "The default character is <strong>Wolverine</strong>, you can change it by passing another characterId.<br>" +
                    "The standard amount of results is 15, you can change it as well. <br>" +
                    "The response will be a csv file like: <strong>characterId_Current_Date.csv</strong></h4>",
                    Contact = new OpenApiContact
                    {
                        Email = "regislima1391@gmail.com",
                        Name = "Regis Lima",
                        Url = new Uri("https://www.linkedin.com/in/regisbr13/")
                    }
                });
            });

        public static void UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarvelServiceIntegration.Api v1");
                    c.RoutePrefix = string.Empty;
                });
        }
    }
}