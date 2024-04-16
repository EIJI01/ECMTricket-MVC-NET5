using ECMTricket.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECMTricket.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(int id, T entity);
        Task Delete(T entity);
    }
}
