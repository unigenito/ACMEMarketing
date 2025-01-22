using Application.Interfaces;

namespace Persistence.Data;

public class UnitOfWork: IUnitOfwork
{
    private readonly AppDbContext _context;
    public AppDbContext Context => _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class
    {
        return new GenericReposirtory<TEntity>(_context);
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        throw new NotImplementedException();
    }

    public Task<int> CompleteAsync()
    {
        throw new NotImplementedException();
    }
}