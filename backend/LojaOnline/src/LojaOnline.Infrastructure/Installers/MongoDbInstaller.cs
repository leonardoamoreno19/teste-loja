using LojaOnline.Domain.Orders;
using LojaOnline.Infrastructure.BackgroundTasks;
using LojaOnline.Infrastructure.Data.MongoDb;
using LojaOnline.Infrastructure.Data.MongoDb.Repositories;
using LojaOnline.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LojaOnline.Infrastructure.Installers
{
    public static class MongoDbInstaller
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoDbSettings = configuration.GetSection("MongoDb").Get<MongoDbSettings>();
            services.AddSingleton(mongoDbSettings);

            services.AddSingleton<MongoDbContext>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddHostedService<OrderSyncService>();

            return services;
        }
    }
}
