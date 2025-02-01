using System.Threading.Tasks;
using LojaOnline.Domain.Entities;
using LojaOnline.Domain.Orders;
using LojaOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LojaOnline.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Order> GetOrderWithItemsAsync(int orderId)
        {
            return await _dbSet
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<Order> GetOrderWithCustomerAsync(int orderId)
        {
            return await _dbSet
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<Order> GetOrderFullDetailsAsync(int orderId)
        {
            return await _dbSet
                .Include(o => o.Customer)
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
