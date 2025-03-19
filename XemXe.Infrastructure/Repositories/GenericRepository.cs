using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using XemXe.Domain.Repositories;
using XemXe.Infrastructure.Data;

namespace XemXe.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class 
{
    protected readonly CarDbContext _context;
    private readonly DbSet<T> _entities;

    public GenericRepository(CarDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }
    
    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _entities.FindAsync(id);
    }
    
    public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _entities.Where(predicate).ToListAsync();
    }

    public void Add(T entity)
    {
        _entities.Add(entity);
    }

    public void Update(T entity)
    {
        _entities.Update(entity);
    }

    public void Delete(T entity)
    {
        _entities.Remove(entity);
    }
}