using System.Threading.Tasks;
using LojaOnline.Domain.Entities;
using LojaOnline.Domain.Shared;

namespace LojaOnline.Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByEmailAsync(string email);
        Task<bool> IsEmailUniqueAsync(string email);
    }
}
