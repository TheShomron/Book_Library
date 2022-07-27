namespace Library.DAL
{
    public interface IRepository<T>
    {
        T Add(T item);
        IQueryable<T> Get();
        T Get(Guid id);
        T Update(T item);
        T Delete(Guid id);
    }
}