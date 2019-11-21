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
            //Inyeccion de dependencias - inversión de control (IoC)
            //https://docs.microsoft.com/es-es/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.0#service-lifetimes-and-registration-options
            //------------------------------------------------------
            //* Los servicios de duración con ámbito (AddScoped) se crean una vez por solicitud del cliente (conexión).
            services.AddScoped<IProductsBLL,ProductsBLL>();
            //* Los servicios con duración Singleton (AddSingleton) se crean la primera vez que se solicitan, o bien al ejecutar Startup.ConfigureServices y especificar una instancia con el registro del servicio. Cada solicitud posterior usa la misma instancia. Si la aplicación requiere un comportamiento de singleton, se recomienda permitir que el contenedor de servicios administre la duración del servicio. No implemente el patrón de diseño de singleton y proporcione el código de usuario para administrar la duración del objeto en la clase.
            //services.AddSingleton<IProductsBLL, ProductsBLL>();
            //* Los servicios de duración transitoria (AddTransient) se crean cada vez que el contenedor del servicio los solicita. Esta duración funciona mejor para servicios sin estado ligeros.
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
