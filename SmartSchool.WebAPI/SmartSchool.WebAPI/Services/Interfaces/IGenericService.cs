namespace SmartSchool.WebAPI.Services.Interfaces;

public interface IGenericService<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task Create(T entity);
    Task Update(T entity, int id);
    Task Remove(int id);
}