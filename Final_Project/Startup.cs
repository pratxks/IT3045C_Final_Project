using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project.Data;
using Final_Project.Interfaces;
using Final_Project.Services;

namespace Final_Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //This method gets called by the runtime. Use this method to add services to the container.
        //Pratik Chaudhari
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerDocument();

            services.AddDbContext<StudentAccessContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString")));
            services.AddScoped<IStudentAccessInterface, StudentAccessService>();

            services.AddDbContext<HobbyAccessContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString")));
            services.AddScoped<IHobbyAccessInterface, HobbyAccessService>();

            services.AddDbContext<SportAccessContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString")));
            services.AddScoped<ISportAccessInterface, SportAccessService>();

            services.AddDbContext<FoodAccessContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString")));
            services.AddScoped<IFoodAccessInterface, FoodAccessService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Pratik Chaudhari
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            StudentAccessContext studentAccessContext, HobbyAccessContext hobbyAccessContext,
            SportAccessContext sportAccessContext, FoodAccessContext foodAccessContext)

        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();

            app.UseSwaggerUi3(c =>
            {
                c.DocumentTitle = "Pratik's Final Project MVC";
            });

            studentAccessContext.Database.Migrate();

            hobbyAccessContext.Database.Migrate();

            sportAccessContext.Database.Migrate();

            foodAccessContext.Database.Migrate();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
