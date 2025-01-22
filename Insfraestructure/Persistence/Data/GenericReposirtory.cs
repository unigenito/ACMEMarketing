using System.Linq.Expressions;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public class GenericReposirtory<TEntity>: IGenericRepository<TEntity> where TEntity : class
{
    private DbSet<TEntity> _dbSet;
    private AppDbContext _appDbContext;
    public GenericReposirtory(AppDbContext context)
    {
        _appDbContext = context;
        _dbSet = context.Set<TEntity>();
    }
    public Task<TEntity> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, IList<string>? includes = null)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }
}