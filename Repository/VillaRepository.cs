using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Villa_Api.Data;
using Villa_Api.Model;
using Villa_Api.Repository.IRepository;

namespace Villa_Api.Repository;

public class VillaRepository : Repository<Villa>, IVillaRepository
{
    private readonly ApplicationDbContext _db;

    public VillaRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public async Task<Villa> Update(Villa entity)
    {
        entity.UpdatedDate = DateTime.Now;
        _db.Villas.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}