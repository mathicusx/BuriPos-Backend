using BuriPosApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuriPosApi.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(int productId);
        Task<Product> FindByIdAsync(int id);
    }
}
