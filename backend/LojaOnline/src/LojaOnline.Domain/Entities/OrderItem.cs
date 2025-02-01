using System;

namespace LojaOnline.Domain.Entities
{
    public class OrderItem : Entity
    {
        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }

        public Order Order { get; private set; }

        protected OrderItem() { } // For EF Core

        public OrderItem(int productId, string productName, int quantity, decimal unitPrice)
        {
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));
            if (unitPrice < 0) throw new ArgumentException("Unit price cannot be negative", nameof(unitPrice));

            ProductId = productId;
            ProductName = productName ?? throw new ArgumentNullException(nameof(productName));
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalPrice = quantity * unitPrice;
        }

        public void UpdateQuantity(int quantity)
        {
            if (quantity <= 0) throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));
            
            Quantity = quantity;
            TotalPrice = quantity * UnitPrice;
        }
    }
}
