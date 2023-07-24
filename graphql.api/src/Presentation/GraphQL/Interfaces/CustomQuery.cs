using graphql.api.src.Infraestructure.Data.Repositories.Abstractions;

namespace graphql.api.src.Presentation.GraphQL.Interfaces
{
    public class CustomQuery<T> : ICustomQuery<T> where T : class
    {
        public readonly IRepository<T> _repository;
        public CustomQuery(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IEnumerable<T> Entities()
        {
            return _repository.GetAll();
        }

        public T Entity(long id)
        {
            return _repository.Get(id);
        }
    }
}
