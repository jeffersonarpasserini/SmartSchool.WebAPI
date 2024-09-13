using Microsoft.EntityFrameworkCore;

namespace SmartSchool.WebAPI.Data;

public class Repository : IRepository
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        this._context = context;
    }

    public IEnumerable<T> Get<T>() where T : class
    {
        return _context.Set<T>().AsNoTracking().ToList();
    }

    public T GetById<T>(int id) where T : class
    {
        return _context.Set<T>().AsNoTracking()
            .FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
    }

    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Update(entity);
    }

    public void Remove<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() > 0);
    }
}