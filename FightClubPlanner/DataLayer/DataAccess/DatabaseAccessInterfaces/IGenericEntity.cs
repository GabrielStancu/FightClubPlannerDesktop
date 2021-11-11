using DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.DataAccess.DatabaseAccess
{
    public interface IGenericEntity<T> where T : BaseModel
    {
        Task DeleteAsync(T entity);
        Task InsertAsync(T entity);
        Task<List<T>> SelectAllAsync();
        Task<T> SelectByIdAsync(int id);
        Task UpdateAsync(T entity);
    }
}