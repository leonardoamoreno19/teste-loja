using LojaOnline.Domain.Customers;
using LojaOnline.Domain.Orders;
using LojaOnline.Domain.Products;
using LojaOnline.Infrastructure.Data;
using LojaOnline.Infrastructure.Data.MongoDb.Repositories;
using LojaOnline.Infrastructure.Repositories;
using DomainOrderReadRepository = LojaOnline.Domain.Orders.IOrderReadRepository;
using MongoDbOrderReadRepository = LojaOnline.Infrastructure.Data.MongoDb.Repositories.OrderReadRepository;

namespace LojaOnline.WebApi.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<DomainOrderReadRepository, MongoDbOrderReadRepository>();

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddScoped<ApplicationDbContext>();
        }
    }
}
