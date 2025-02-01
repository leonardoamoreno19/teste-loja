using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LojaOnline.Domain.Orders;
using LojaOnline.Infrastructure.Data.MongoDb;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace LojaOnline.Infrastructure.BackgroundTasks
{
    public class OrderSyncService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly MongoDbContext _mongoContext;

        public OrderSyncService(
            IServiceProvider serviceProvider,
            MongoDbContext mongoContext)
        {
            _serviceProvider = serviceProvider;
            _mongoContext = mongoContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();
                    var orders = await orderRepository.GetAllAsync("Customer");
                    
                    var collection = _mongoContext.GetCollection<OrderReadModel>("Orders");

                    foreach (var order in orders)
                    {
                        var readModel = new OrderReadModel
                        {
                            Id = order.Id,
                            CustomerId = order.CustomerId,
                            CustomerName = order.Customer?.Name ?? string.Empty,
                            CustomerEmail = order.Customer?.Email ?? string.Empty,
                            OrderDate = order.OrderDate,
                            TotalAmount = order.TotalAmount,
                            Status = order.Status,
                            Items = order.Items.Select(item => new OrderItemReadModel
                            {
                                Id = item.Id,
                                ProductId = item.ProductId,
                                ProductName = item.ProductName ?? string.Empty,
                                Quantity = item.Quantity,
                                UnitPrice = item.UnitPrice,
                                TotalPrice = item.TotalPrice
                            }).ToList() ?? new List<OrderItemReadModel>()
                        };

                        await collection.ReplaceOneAsync(
                            x => x.Id == readModel.Id,
                            readModel,
                            new ReplaceOptions { IsUpsert = true },
                            stoppingToken);
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
