using graphql.api.src.Infraestructure.Data.Repositories.Abstractions;

namespace graphql.api.src.Application.Services.Abstractions
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T Add(T entity)
        {
            return _repository.Add(entity);
        }

        public T Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Remove(long id)
        {
            return _repository.Remove(id);
        }

        public T Update(long id, T entity)
        {
            return _repository.Update(id, entity);
        }
    }
}
