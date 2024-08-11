namespace BuriPosApi.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        Task<int> CompleteAsync();  // Saves all changes in the context

    }
}