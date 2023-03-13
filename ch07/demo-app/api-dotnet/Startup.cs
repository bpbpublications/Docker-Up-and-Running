using System;
using System.Linq;
using api_dotnet.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace api_dotnet
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
            var connString = Configuration.GetConnectionString("DemoDB");
            services.AddDbContext<DataContext>(
                options => options.UseNpgsql(connString));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "api_dotnet", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            if(context.Database.EnsureCreated())
                SeedDatabase(context);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api_dotnet v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SeedDatabase(DataContext context)
        {
            Console.WriteLine("Trying to access DB... waiting 2 sec.");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Now trying to access DB...");
            if(context.Orders.Count() > 0)
                return; // only add seed if empty...
            context.Orders.AddRange(new []{
                new Order{ OrderDate = new DateTime(2021,8,1), Status = OrderStatus.Fulfilled },
                new Order{ OrderDate = new DateTime(2021,8,1), Status = OrderStatus.Accepted },
                new Order{ OrderDate = new DateTime(2021,8,2), Status = OrderStatus.Fulfilled },
                new Order{ OrderDate = new DateTime(2021,8,3), Status = OrderStatus.Accepted },
                new Order{ OrderDate = new DateTime(2021,8,3), Status = OrderStatus.Draft },
            });
            context.SaveChanges();
        }
    }
}
