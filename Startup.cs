using CRUD.Context;
using CRUD.Repository;
using CRUD.Repository.Interfaces;
using CRUD.Services;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CRUD
{
#pragma warning disable 1591
    public class Startup
    {

        private const string SWAGGERFILE_PATH = "./swagger/v1/swagger.json";
        private const string API_VERSION = "v1";
        private const string PROJECT_NAME = "API CRUD";
        private const string XML_EXTENSION = ".xml";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            AddSwagger(services);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.RoutePrefix = string.Empty;
                    c.SwaggerEndpoint(SWAGGERFILE_PATH, PROJECT_NAME + API_VERSION);
                });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(API_VERSION, new OpenApiInfo { Title = PROJECT_NAME, Version = API_VERSION });

                var xmlFile = Assembly.GetExecutingAssembly().GetName().Name + XML_EXTENSION;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
