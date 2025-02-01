using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaOnline.Domain.Orders
{
    public class OrderReadModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public System.DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Enums.OrderStatus Status { get; set; }
        public List<OrderItemReadModel> Items { get; set; } = new();
    }

    public class OrderItemReadModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public interface IOrderReadRepository
    {
        Task<OrderReadModel> GetByIdAsync(int id);
        Task<List<OrderReadModel>> GetAllAsync();
    }
}
