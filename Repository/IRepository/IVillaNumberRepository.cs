using System.Linq.Expressions;
using Villa_Api.Model;

namespace Villa_Api.Repository.IRepository;

public interface IVillaNumberRepository : IRepository<VillaNumber>
{
    Task<VillaNumber> Update(VillaNumber entity);
}