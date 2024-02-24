namespace Assignment.Contracts.Data.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(object id);
        T Get(string id);
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        int Count();
        
    }
}