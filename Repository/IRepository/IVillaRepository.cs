using System.Linq.Expressions;
using Villa_Api.Model;

namespace Villa_Api.Repository.IRepository;

public interface IVillaRepository : IRepository<Villa>
{
    Task<Villa> Update(Villa entity);
}