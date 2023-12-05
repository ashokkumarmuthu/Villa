using System.Linq.Expressions;
using Villa_Api.Model;

namespace Villa_Api.Repository.IRepository;

public interface IRepository<T> where T : class
{
    Task Create(T entity);
    Task Remove(T entity);
    Task Save();
}