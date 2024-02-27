namespace DataProcessor.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> Get(string id);
    Task<IEnumerable<T>> GetAll();
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task Delete(string id);
}
