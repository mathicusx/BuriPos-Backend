using BuriPosApi.Data;
using BuriPosApi.Features.Products.Interfaces;
using BuriPosApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuriPosApi.Features.Products.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            await _appDbContext.Products.AddAsync(product);
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _appDbContext.Products.FindAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }

            _appDbContext.Products.Remove(product);
        }

        public async Task<Product> FindProductByIdAsync(long id)
        {
            var product = await _appDbContext.Products.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _appDbContext.Products.ToListAsync();
        }
    }
}
