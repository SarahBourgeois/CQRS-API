using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly CrushOnContext _crushOnContext;

    public Repository(CrushOnContext crushOnContext)
    {
        _crushOnContext = crushOnContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _crushOnContext.Set<T>().AddAsync(entity);
        await _crushOnContext.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _crushOnContext.Set<T>().Remove(entity);
        await _crushOnContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync() =>  await _crushOnContext.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(int id) => await _crushOnContext.Set<T>().FindAsync(id);
    
    public Task UpdateAsync(T entity) => throw new NotImplementedException();
}