using System;

namespace LojaOnline.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        protected Product() 
        { 
            Name = string.Empty;
        }

        public Product(string name, decimal price)
        {
            if (price < 0) throw new ArgumentException("Price cannot be negative", nameof(price));
            
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }

        public void Update(string name, decimal price)
        {
            if (price < 0) throw new ArgumentException("Price cannot be negative", nameof(price));
            
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
        }
    }
}
