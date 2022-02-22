using Kattalist.Domain.Entities;
using Kattalist.Domain.Interfaces;
using Kattalist.Infra.Data.Context;
using Kattalist.Infra.Data.Repository;
using Kattalist.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace Kattalist.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
         
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddAutoMapper(typeof(Kattalist.Domain.Entities.AutoMapperProfile));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Kattalist.API", Version = "v1" });
            });

            services.AddDbContext<KattalistDbContext>(Options => Options
            .UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            services.AddTransient(typeof(IBaseService<GroceryList>), typeof(BaseService<GroceryList>));
            services.AddTransient(typeof(IBaseRepository<GroceryList>), typeof(BaseRepository<GroceryList>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kattalist.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
