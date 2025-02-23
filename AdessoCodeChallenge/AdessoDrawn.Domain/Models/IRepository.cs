public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> includeFunc = null);
    Task<T> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}
