namespace Application.Interfaces;

public interface IUnitOfwork:IDisposable
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> CompleteAsync();
}