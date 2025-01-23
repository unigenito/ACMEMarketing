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
    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, IList<string>? includes = null)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        await Task.Run(() => _dbSet.Update(entity));
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Remove(TEntity entity)
    {
         _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}