using BuriPosApi.Models;


namespace BuriPosApi.Features.Products.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(int productId);
        Task<Product> FindProductByIdAsync(long id);
    }
}
