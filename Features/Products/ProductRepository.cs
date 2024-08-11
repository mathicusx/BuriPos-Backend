using BuriPosApi.Interfaces;
using BuriPosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BuriPosApi.Data.Repo
{
    public class ProductRepository(AppDbContext appDbContext) : IProductRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task AddProductAsync(Product product)
        {
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _appDbContext.Products.FindAsync(productId) ?? throw new KeyNotFoundException($"Product with ID {productId} not found.");
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            var product = await _appDbContext.Products.FindAsync(id) ?? throw new KeyNotFoundException($"Product with ID {id} not found.");
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _appDbContext.Products.ToListAsync();
        }
    }
}
