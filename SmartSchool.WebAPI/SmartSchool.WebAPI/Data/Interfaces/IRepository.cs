namespace SmartSchool.WebAPI.Data;

public interface IRepository
{
    IEnumerable<T> Get<T>() where T : class;
    T GetById<T>(int id) where T : class;
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Remove<T>(T entity) where T : class;
    bool SaveChanges();
}