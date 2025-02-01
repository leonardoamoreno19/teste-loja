using System;
using System.Collections.Generic;
using System.Linq;
using LojaOnline.Domain.Enums;

namespace LojaOnline.Domain.Entities
{
    public class Order : Entity
    {
        private readonly List<OrderItem> _items;
        
        public int CustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal TotalAmount { get; private set; }
        public OrderStatus Status { get; private set; }
        
        public Customer Customer { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        protected Order() 
        {
            _items = new List<OrderItem>();
        }

        public Order(int customerId, DateTime orderDate)
        {
            CustomerId = customerId;
            OrderDate = orderDate;
            Status = OrderStatus.Pending;
            _items = new List<OrderItem>();
            TotalAmount = 0;
        }

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
            RecalculateTotal();
        }

        public void RemoveItem(OrderItem item)
        {
            _items.Remove(item);
            RecalculateTotal();
        }

        public void UpdateStatus(OrderStatus status)
        {
            Status = status;
        }

        private void RecalculateTotal()
        {
            TotalAmount = _items.Sum(i => i.TotalPrice);
        }
    }
}
