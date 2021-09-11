using AppliancesModel;
using AppliancesModel.Contracts;
using AppliancesModel.Models;
using DeliveryService.BLL.Contracts;
using DeliveryService.BLL.Models;
using DeliveryServiceModel;
using EFCore5.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace DeliveryService
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
            services.AddScoped<IDataSerialization, DataSerialization>();
            services.AddScoped<ICacheable, Cache>();
            services.AddDbContext<DataContext>(
                options => options.UseSqlServer("Data Source=.; Integrated Security=True; Initial Catalog = DeliveryServiceEFData"));
            services.AddScoped<IRepository<User>, UserRepository>();

            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<Carrier>, CarrierRepository>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<Supplier>, SupplierRepository>();
            services.AddScoped<IRepository<Tariff>, TariffRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ICurrencyConverter, CurrencyConverter>();
            services.AddScoped<IConverterService, ConverterService>();
            services.AddScoped<IAppliancesDistribution, AppliancesDistribution>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<ISupplierManager, SupplierManager>();

            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeliveryService", Version = "v1" });
            }); 
            services.PostConfigure<MvcNewtonsoftJsonOptions>(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeliveryService v1"));
            }

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
