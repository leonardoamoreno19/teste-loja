using System.Threading.Tasks;
using LojaOnline.Domain.Customers;
using LojaOnline.Domain.Entities;
using LojaOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LojaOnline.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return !await _dbSet.AnyAsync(c => c.Email == email);
        }
    }
}
