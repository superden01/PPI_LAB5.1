using System.Linq;
using HTTPLessonApi.DAL.Repositories;
using HTTPLessonApi.Domain.Entity;
using HTTPLessonApi.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HTTPLessonApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions (apiDescriptions => apiDescriptions.First ());
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "HTTPApi", Version = "v1"});
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HTTPApi v1"));
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}