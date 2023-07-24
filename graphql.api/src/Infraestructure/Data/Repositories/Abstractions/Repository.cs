using graphql.api.src.Infraestructure.Data.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace graphql.api.src.Infraestructure.Data.Repositories.Abstractions
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BancoContext _context;
        public DbSet<T> _repository;

        public Repository(BancoContext context)
        {
            _context = context;
            _repository = _context.Set<T>();
        }

        public T Add(T entity)
        {
            _repository.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Get(long id)
        {
            return _repository.ToList().FirstOrDefault( e => GetPropertyValue<long>(e) == id );
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.ToList();
        }

        public bool Remove(long id)
        {
            throw new NotImplementedException();
        }

        public T Update(long id, T entity)
        {
            throw new NotImplementedException();
        }


        private static TProperty GetPropertyValue<TProperty>(object obj)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty("Id");
            if (propertyInfo != null && propertyInfo.PropertyType == typeof(TProperty))
            {
                return (TProperty)propertyInfo.GetValue(obj);
            }
            return default;
        }
    }
}
