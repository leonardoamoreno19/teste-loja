using System.Threading.Tasks;
using LojaOnline.Domain.Entities;
using LojaOnline.Domain.Products;
using LojaOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LojaOnline.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Product?> GetByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<bool> IsNameUniqueAsync(string name)
        {
            return !await _dbSet.AnyAsync(p => p.Name == name);
        }
    }
}
