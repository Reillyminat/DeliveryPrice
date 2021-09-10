using AppliancesModel;
using AppliancesModel.Contracts;
using AppliancesModel.Models;
using DeliveryService.API.Filters;
using DeliveryService.BLL.Contracts;
using DeliveryServiceModel;
using EFCore5.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DeliveryService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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

            services.AddControllersWithViews();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeliveryService", Version = "v1" });
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddSingleton<CustomExceptionAttribute>();
            services.AddTransient<CustomActionAttribute>();
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
