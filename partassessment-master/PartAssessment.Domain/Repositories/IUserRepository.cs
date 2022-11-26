using PartAssessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsername(string username);
        Task<List<User>> GetByRole(string role);
    }
}
