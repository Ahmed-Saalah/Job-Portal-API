using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Interfaces
{
    public interface IDapperRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string query);
        Task<T> GetByIdAsync(string query, object parameters);
        Task<IEnumerable<T>> FindAsync(string query, object parameters);
    }
}
