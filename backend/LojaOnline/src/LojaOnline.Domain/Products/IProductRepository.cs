using System.Threading.Tasks;
using LojaOnline.Domain.Entities;
using LojaOnline.Domain.Shared;

namespace LojaOnline.Domain.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetByNameAsync(string name);
        Task<bool> IsNameUniqueAsync(string name);
    }
}
