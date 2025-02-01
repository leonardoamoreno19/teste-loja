using System.Threading.Tasks;
using LojaOnline.Domain.Entities;
using LojaOnline.Domain.Shared;

namespace LojaOnline.Domain.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOrderWithItemsAsync(int orderId);
        Task<Order> GetOrderWithCustomerAsync(int orderId);
        Task<Order> GetOrderFullDetailsAsync(int orderId);
    }
}
