using graphql.api.src.Application.Entities;
using graphql.api.src.Infraestructure.Data.Repositories.Abstractions;

namespace graphql.api.src.Presentation.GraphQL.Interfaces
{
    public class CustomMutation<T> : ICustomMutation<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public CustomMutation(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T Add(T entity)
        {
            return _repository.Add(entity);
        }

        public bool Remove(long id)
        {
            return _repository.Remove(id);
        }

        public T Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
