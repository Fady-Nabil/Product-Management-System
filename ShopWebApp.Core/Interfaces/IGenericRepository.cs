using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWebApp.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
