namespace graphql.api.src.Presentation.GraphQL.Interfaces
{
    public interface ICustomQuery<T> where T : class
    {
        IEnumerable<T> Entities();
        T Entity(long id);
    }
}
