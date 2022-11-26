using PartAssessment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Domain.Entities
{
    public class User : EntityBase, IAggregateRoot
    {
        private User()
        {
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public virtual ICollection<UserRole> UserRoles { get; private set; }

        public static User GetInstance(string firstName, string lastName, string username, string password, List<UserRole> userRoles = null)
        {
            return new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = password,
                UserRoles = userRoles
            };
        }
    }
}
