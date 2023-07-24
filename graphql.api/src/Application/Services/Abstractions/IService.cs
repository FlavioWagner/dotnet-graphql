namespace graphql.api.src.Application.Services.Abstractions
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        T Add(T entity);
        T Update(long id, T entity);
        bool Remove(long id);
    }
}
