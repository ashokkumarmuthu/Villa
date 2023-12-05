using System.Linq.Expressions;
using Villa_Api.Model;

namespace Villa_Api.Services.IServices;

public interface IVillaService
{
    Task Create(Villa entity);
    Task Remove(Villa entity);
    Task<Villa> Update(Villa entity);
    Task<Villa> Get(Expression<Func<Villa,bool>> filter = null, bool tracked = true);
    Task<List<Villa>> GetAll(Expression<Func<Villa,bool>>? filter = null);
}