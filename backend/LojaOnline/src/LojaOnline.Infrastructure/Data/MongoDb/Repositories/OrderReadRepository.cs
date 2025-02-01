using System.Collections.Generic;
using System.Threading.Tasks;
using LojaOnline.Domain.Orders;
using MongoDB.Driver;

namespace LojaOnline.Infrastructure.Data.MongoDb.Repositories
{
    public class OrderReadRepository : LojaOnline.Domain.Orders.IOrderReadRepository
    {
        private readonly IMongoCollection<OrderReadModel> _collection;

        public OrderReadRepository(MongoDbContext context)
        {
            _collection = context.GetCollection<OrderReadModel>("Orders");
        }

        public async Task<OrderReadModel> GetByIdAsync(int id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<OrderReadModel>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
    }
}
