namespace graphql.api.src.Infraestructure.Data.Repositories.Abstractions
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();        
        T Get(long id);
        T Add(T entity);
        T Update(long id, T entity);
        bool Remove(long id);
    }
}
