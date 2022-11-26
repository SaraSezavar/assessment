
using PartAssessment.Domain.Entities;
using PartAssessment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        #region 
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        #endregion Ctor

        #region Query side
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Users
                .Where(p => p.Username.ToLower().Equals(username.ToLower()))
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync();
        }
        public async Task<List<User>> GetByRole(string role)
        {
            return await _context.Users
                .Where(p => p.UserRoles.Any(x => x.Role.Name.ToLower().Equals(role.ToLower())))
                .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                .ToListAsync();
        }
        #endregion Query side

        #region Command side
        public async Task<User> AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }
        #endregion Command side
    }
}
