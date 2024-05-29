namespace Recipe.Users.Data.Interfaces
{
    public interface IRepository<T> where T : class{
        IEnumerable<T> GetAll();
        T? GetBy(Func<T, bool> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
