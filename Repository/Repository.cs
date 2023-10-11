using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Villa_Api.Data;
using Villa_Api.Model;
using Villa_Api.Repository.IRepository;

namespace Villa_Api.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _db;
    internal DbSet<T> dbset;
    public Repository(ApplicationDbContext db)
    {
        _db = db;
        this.dbset = _db.Set<T>();
    }
    public async Task Create(T entity)
    {
        await dbset.AddAsync(entity);
        await Save();
    }

    public async Task Remove(T entity)
    {
        dbset.Remove(entity);
        await Save();
    }

    public async Task<T> Get(Expression<Func<T, bool>> filter = null, bool tracked = true)
    {
        IQueryable<T> query = dbset;
        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = dbset;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        return await query.ToListAsync();
    }
    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }
}