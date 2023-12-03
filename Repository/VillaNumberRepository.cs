using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Villa_Api.Data;
using Villa_Api.Model;
using Villa_Api.Repository.IRepository;

namespace Villa_Api.Repository;

public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
{
    private readonly ApplicationDbContext _db;

    public VillaNumberRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public async Task<VillaNumber> Update(VillaNumber entity)
    {
        entity.UpdatedDate = DateTime.Now;
        _db.VillaNumber.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }
}