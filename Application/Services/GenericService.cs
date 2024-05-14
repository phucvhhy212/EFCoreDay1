using Application.IServices;
using Microsoft.Extensions.Logging;
using System.Reflection;
using ApplicationDbContext = Infrastructure.ApplicationDbContext;

namespace Application.Services
{
    public class GenericService<T> : IGenericService<T>
        where T : class
    {
        protected readonly ILogger<GenericService<T>> _logger;
        public readonly ApplicationDbContext dbContext;

        public GenericService(ILogger<GenericService<T>> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public IEnumerable<T> Get()
        {
            _logger.LogInformation($"Getting all {typeof(T).FullName}");
            return dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _logger.LogInformation($"Creating new {typeof(T).FullName}");
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _logger.LogInformation($"Deleting {typeof(T).FullName}");
            PropertyInfo propertyInfo = entity.GetType().GetProperty("DeletedAt");
            propertyInfo.SetValue(entity, DateTime.Now);
            Update(entity);
        }

        public void Delete(Guid id)
        {
            _logger.LogInformation($"Finding {typeof(T).FullName} with id = {id} to delete");

            var entityToDelete = Find(id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
                dbContext.SaveChanges();
            }
            else
            {
                _logger.LogError($"{typeof(T).FullName} with id = {id} not exist to delete");
                throw new Exception("Cannot find entity to delete");
            }
        }

        public void Update(T entity)
        {
            _logger.LogInformation($"Updating {typeof(T).FullName}");
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();
        }

        public T? Find(Guid id)
        {
            _logger.LogInformation($"Finding {typeof(T).FullName} with id = {id}");
            return dbContext.Set<T>().Find(id);
        }

        public T? Find(T entity)
        {
            _logger.LogInformation($"Finding {typeof(T).FullName}");
            return dbContext.Set<T>().Find(entity);
        }
    }
}
