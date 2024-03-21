﻿using Microsoft.OpenApi.Models;

namespace Senac.eShop.API.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "eShop API",
                    Description = "Esta API é feita como parte do curso" +
                    " técnico em TI - Senac",
                    Contact = new OpenApiContact()
                    {
                        Name = "Senac",
                        Email = "contato@go.senac.br"
                    }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
            });

        }
    }
}
