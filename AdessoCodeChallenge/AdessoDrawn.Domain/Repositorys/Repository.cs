using AdessoDraw.Domain.Context;
using Microsoft.EntityFrameworkCore;


namespace AdessoDraw.Domain.Repositorys;
public class Repository<T> : IRepository<T> where T : class
{
    private readonly DrawContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(DrawContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    // GetAllAsync metodunu, ilişkili verileri de dahil edecek şekilde güncelliyoruz.
    public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> includeFunc = null)
    {
        IQueryable<T> query = _dbSet;

        if (includeFunc != null)
        {
            query = includeFunc(query); // includeFunc fonksiyonunu uyguluyoruz
        }

        return await query.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
