using System;
using MicroShop.Core.Bus;
using MicroShop.Core.Bus.RabbitMq;
using MicroShop.Core.Entities;
using MicroShop.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace MicroShop.ApiGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            //var httpServices = Configuration.GetOptions<HttpServiceOptions>("HttpServices");
            //services.AddHttpClient<ICustomerHttpService, CustomerHttpService>(client =>
            //{
            //    client.BaseAddress = new Uri(httpServices.CustomerHttpServiceUrl);
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //});
            //services.AddHttpClient<IProductHttpService, ProductHttpService>(client =>
            //{
            //    client.BaseAddress = new Uri(httpServices.ProductHttpServiceUrl);
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //});
            return services.BuildContainer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
