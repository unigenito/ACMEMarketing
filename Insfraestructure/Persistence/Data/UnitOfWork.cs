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

    public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        return new GenericReposirtory<TEntity>(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}