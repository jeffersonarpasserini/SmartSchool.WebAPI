using Microsoft.EntityFrameworkCore;

namespace SmartSchool.WebAPI.Data;

public class GenericRepository<T> : IGenericRepository<T> where T: class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        this._context = context;
        this._dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> Get()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveChanges();
    }

    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await SaveChanges();
    }

    public async Task Remove(T entity)
    {
        _dbSet.Remove(entity);
        await SaveChanges();
    }

    public async Task<bool> SaveChanges()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}