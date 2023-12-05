using System.Linq.Expressions;
using System.Runtime;
using Microsoft.EntityFrameworkCore;
using Villa_Api.Data;
using Villa_Api.Model;
using Villa_Api.Repository.IRepository;
using Villa_Api.Services.IServices;

namespace Villa_Api.Services;

public class VillaService: IVillaService
{
    private readonly IVillaRepository _repo;
    public VillaService(IVillaRepository db)
    {
        _repo = db;
    }
    public async Task Create(Villa entity)
    {
        await _repo.Create(entity);
    }

    public async Task<Villa> Update(Villa entity)
    {
        entity.UpdatedDate = DateTime.Now;
        entity = await _repo.Update(entity);
        return entity;
    }
    public async Task Remove(Villa entity)
    {
        await _repo.Remove(entity);
    }

    public async Task<Villa> Get(Expression<Func<Villa, bool>> filter = null, bool tracked = true)
    {
        IQueryable<Villa> query = _repo.Getdb();
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
        IQueryable<Villa> query = _repo.Getdb();
        if (filter != null)
        {
            query = query.Where(filter);
        }
        return await query.ToListAsync();
    }
}