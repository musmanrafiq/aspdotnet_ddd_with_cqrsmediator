using Project.Data;
using Project.Data.IRepositories;
using Project.Data.Repositories;
using Project.Service.Dxos;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System;

namespace Project.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            // Read configuration and combine appsettings.json and appsettings.env.json by environment of deployment
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddMvc(x => x.EnableEndpointRouting = false).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddDbContext<ProjectDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                        sqlOptions =>
                        {
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorNumbersToAdd: null);
                        });
                });
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Project API", Version = "v1" });
            });

            //Add DIs
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectDxos, ProjectDxos>();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddLogging();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //You may would disable auto migrate if needed
            app.UseAutoMigrateDatabase<ProjectDbContext>();
            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project API V1"); });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}