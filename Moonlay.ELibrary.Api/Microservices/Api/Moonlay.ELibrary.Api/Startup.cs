using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Moonlay.ELibrary.Application.Interfaces;
using Moonlay.ELibrary.Application.Services;
using Moonlay.ELibrary.Data.Models;
using Moonlay.ELibrary.Data.Repository;
using Moonlay.ELibrary.Domain.Interfaces;

namespace Moonlay.ELibrary.Api
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

            services.AddTransient<ILibraryRepository, LibraryRepository>();
            services.AddTransient<IRentBookService, RentBookService>();

            services.AddDbContext<ELibraryContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Development"));
            });



            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Moonlay ELibray API",
                    Description = "Moonlay ELibray API",
                    TermsOfService = new Uri(@"https://www.hari.co.id/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Moonlay ELibray.com",
                        Email = "support@hari.com",
                        Url = new Uri(@"https://www.hari.co.id/contact-us"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Moonlay ELibray License",
                        Url = new Uri(@"https://www.hari.co.id/"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Moonlay ELibray API");
                c.RoutePrefix = string.Empty;
            });


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
