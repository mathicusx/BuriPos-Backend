using BuriPosApi.Features.Products.Interfaces;

namespace BuriPosApi.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        Task<int> CompleteAsync();

    }
}