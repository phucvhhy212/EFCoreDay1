namespace Application.IServices
{
    public interface IGenericService<T> where T : class
    {
        public IEnumerable<T> Get();
        public void Add(T entity);
        public void Delete(T entity);
        public void Delete(Guid id);
        public void Update(T entity);
        public T? Find(Guid id);
        public T? Find(T entity);

    }
}
