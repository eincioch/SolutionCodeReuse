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

            //------------------------------------------------------
            //Inyeccion de dependencias - inversi�n de control (IoC)
            //https://docs.microsoft.com/es-es/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0#service-lifetimes-and-registration-options
            //------------------------------------------------------
            //* Los servicios de duraci�n con �mbito (AddScoped) se crean una vez por solicitud del cliente (conexi�n).
            services.AddScoped<IProductsBLL,ProductsBLL>();
            //* Los servicios con duraci�n Singleton (AddSingleton) se crean la primera vez que se solicitan, o bien al ejecutar Startup.ConfigureServices y especificar una instancia con el registro del servicio. Cada solicitud posterior usa la misma instancia. Si la aplicaci�n requiere un comportamiento de singleton, se recomienda permitir que el contenedor de servicios administre la duraci�n del servicio. No implemente el patr�n de dise�o de singleton y proporcione el c�digo de usuario para administrar la duraci�n del objeto en la clase.
            //services.AddSingleton<IProductsBLL, ProductsBLL>();
            //* Los servicios de duraci�n transitoria (AddTransient) se crean cada vez que el contenedor del servicio los solicita. Esta duraci�n funciona mejor para servicios sin estado ligeros.
            //services.AddTransient<IProductsBLL, ProductsBLL>();
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
