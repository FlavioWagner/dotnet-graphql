namespace graphql.api.src.Presentation.GraphQL.Interfaces
{
    public interface ICustomMutation<T> where T : class
    {
        T Add(T entity);
        Boolean Remove(long id);
        T Update(long id,T entity);
    }
}
