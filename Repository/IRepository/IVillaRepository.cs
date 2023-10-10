using System.Linq.Expressions;
using Villa_Api.Model;

namespace Villa_Api.Repository.IRepository;

public interface IVillaRepository
{
    Task Create(Villa entity);
    Task Remove(Villa entity);
    Task<Villa> Get(Expression<Func<Villa,bool>> filter = null, bool tracked = true);
    Task<List<Villa>> GetAll(Expression<Func<Villa,bool>> filter = null);
    Task Update(Villa entity);
    Task Save();
}