using System;
using AutoMapper;
using MediatR;
using MicroShop.Core.Bus.RabbitMq;
using MicroShop.Core.Extensions;
using MicroShop.Services.Customer.Data;
using MicroShop.Services.Customer.Domain.Commands;
using MicroShop.Services.Customer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MicroShop.Services.Customer
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
            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));

            //Add Db Context
            services.AddDbContext<CustomerDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("CustomerDb"))
            );

            services.AddTransient<ICustomerRepository, CustomerRepository>();

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

            //app.UseRabbitMq()
            //    .SubscribeCommand<CreateCustomerCommand>();
            //.SubscribeCommand<AddProductToBasket>()
            //.SubscribeEvent<OrderCompleted>();
        }
    }
}
