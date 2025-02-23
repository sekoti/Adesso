public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> includeFunc = null);
    Task AddAsync(T entity);
}
