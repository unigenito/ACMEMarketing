﻿using System.Linq.Expressions;

namespace Application.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>> predicate, IList<string>? includes = null);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, IList<string>? includes = null);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);   
}