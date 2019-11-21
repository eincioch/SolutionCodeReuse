using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Northwind.BLL.BusinessLogicLayer;
using Northwind.BLL.InterfaceBLL;

namespace Northwind.WebAPI
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

            //----------------
            //Politica de CORS
            //----------------
            services.AddCors(option => {
                option.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyHeader()  //permitir cualquier encabezado me venga
                    .AllowAnyMethod()  //permite PUT, GET, POST, DEELETE .. etc
                );
            });

            //Inyeccion de dependencias
            services.AddScoped(typeof(IProductsBLL), typeof(ProductsBLL));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Omite el redireccionamiento a https
            //app.UseHttpsRedirection();

            app.UseRouting();

            //-----------------------
            //Usar las politicas CORS
            //-----------------------
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
