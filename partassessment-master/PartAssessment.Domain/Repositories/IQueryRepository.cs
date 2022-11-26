using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Domain.Repositories
{
    public interface IQueryRepository<T> where T : EntityBase
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
    }
}
