using BuriPosApi.Data;
using BuriPosApi.Data.Repo;
using BuriPosApi.Interfaces;

namespace BuriPosApi.Data
{
    public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
    {
        private readonly AppDbContext appDbContext = appDbContext;

        public IProductRepository ProductRepository =>
            new ProductRepository(appDbContext);

        public async Task<int> CompleteAsync()
        {
            return await appDbContext.SaveChangesAsync();
        }
    }
}