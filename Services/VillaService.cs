using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Villa_Api.Data;
using Villa_Api.Model;
using Villa_Api.Services.IServices;

namespace Villa_Api.Services;

public class VillaService: IVillaService
{
    private readonly ApplicationDbContext _db;
    internal DbSet<Villa> dbset;
    public VillaService(ApplicationDbContext db)
    {
        _db = db;
        this.dbset = _db.Set<Villa>();
    }
    public async Task Create(Villa entity)
    {
        await dbset.AddAsync(entity);
        await Save();
    }

    public async Task Remove(Villa entity)
    {
        dbset.Remove(entity);
        await Save();
    }

    public async Task<Villa> Get(Expression<Func<Villa, bool>> filter = null, bool tracked = true)
    {
        IQueryable<Villa> query = dbset;
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

    public async Task<List<Villa>> GetAll(Expression<Func<Villa, bool>>? filter = null)
    {
        IQueryable<Villa> query = dbset;
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