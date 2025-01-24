namespace Application.Interfaces;

public interface IUnitOfwork:IDisposable
{
    IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    Task<int> CompleteAsync();
}