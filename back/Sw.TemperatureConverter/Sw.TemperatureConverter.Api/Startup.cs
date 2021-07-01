using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sw.TemperatureConverter.ServiceDxos;
using Sw.TemperatureConverter.ServiceDxos.Interfaces;

namespace Sw.TemperatureConverter.Api
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

            //Add DIs
            
            services.AddScoped<ITemperatureDxos, TemperatureDxos>();

            //Add MediatR
            var assembly = AppDomain.CurrentDomain.Load("Sw.TemperatureConverter.Service");
            services.AddMediatR(assembly);
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


           // app.UseMvc(routes => { routes.MapRoute(name: "towIds", template: "" )});

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "twoids",
            //        // Route pattern
            //        template: "{controller}/{temperatureType}/{action}/{temperatureValue}");
            //});
        }
    }
}