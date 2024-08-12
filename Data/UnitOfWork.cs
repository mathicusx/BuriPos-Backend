using BuriPosApi.Features.Products.Interfaces;
using BuriPosApi.Interfaces;
using BuriPosApi.Data;

namespace BuriPosApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly IProductRepository _productRepository;

        public UnitOfWork(AppDbContext appDbContext, IProductRepository productRepository)
        {
            _appDbContext = appDbContext;
            _productRepository = productRepository;
        }

        public IProductRepository ProductRepository => _productRepository;

        public async Task<int> CompleteAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
