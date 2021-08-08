using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NewWorldAPI.Configuration;
using NewWorldAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWorldAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string AllOrigins = "allOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(name: AllOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins(Configuration.GetSection("AllowedOrigins").Value)
                                             .AllowAnyHeader(); 
                                  });
            });

            // requires using Microsoft.Extensions.Options
            services.Configure<ArticleDatabaseSettings>(
                Configuration.GetSection(nameof(ArticleDatabaseSettings)));

            services.AddSingleton<IArticleDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ArticleDatabaseSettings>>().Value);

            services.AddSingleton<ArticleDAO>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NewWorldAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NewWorldAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(AllOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
