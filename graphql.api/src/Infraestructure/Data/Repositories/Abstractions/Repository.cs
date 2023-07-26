using AutoMapper;
using graphql.api.src.Application.Entities;
using graphql.api.src.Infraestructure.Data.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace graphql.api.src.Infraestructure.Data.Repositories.Abstractions
{
    public class Repository<T> : IRepository<T> where T : class,IEntity
    {
        private readonly IMapper _mapper;
        private readonly BancoContext _context;
        public DbSet<T> _repository;

        public Repository(IMapper mapper,BancoContext context)
        {
            _mapper = mapper;
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
            return _repository.FirstOrDefault( e => e.Id == id );
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.ToList();
        }

        public bool Remove(long id)
        {
            var entity = Get(id);
            if (entity != null)
            {
                _repository.Remove(entity);
                return true;
            }
            return false;
        }

        public T Update(long id, T entity)
        {
            var UpdatedEntity = Get(id);

            if (UpdatedEntity != null)
            {
                var props = entity.GetType().GetProperties();
                foreach (var prop in props)
                {
                    if (prop.Name != "Id")
                    {
                        var value = prop.GetValue(entity, null);
                        var updProp = UpdatedEntity.GetType().GetProperty(prop.Name);
                        updProp.SetValue(UpdatedEntity, value);
                    }
                }

                _repository.Update(UpdatedEntity);
                _context.SaveChanges(true);
                return UpdatedEntity;
            }
            return null;
        }
    }
}
