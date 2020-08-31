using System;
using AutoMapper;
using MediatR;
using MicroShop.Core.Bus.RabbitMq;
using MicroShop.Core.Extensions;
using MicroShop.Services.Product.Data;
using MicroShop.Services.Product.Domain.Commands;
using MicroShop.Services.Product.Repositories;
using MicroShop.Services.Product.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MicroShop.Services.Product
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
            
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<ProductDbContext>(p =>
            {
                p.UseSqlServer(Configuration.GetConnectionString("ProductDb"));
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
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

            //app.UseRabbitMq().SubscribeCommand<CreateProductCommand>();
        }
    }
}
