using System;

namespace LojaOnline.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        protected Customer() 
        {
            Name = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
        }

        public Customer(string name, string email, string phone)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }

        public void Update(string name, string email, string phone)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }
    }
}
