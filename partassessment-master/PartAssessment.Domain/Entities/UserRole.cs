using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Domain.Entities
{
    public class UserRole : EntityBase
    {
        private UserRole()
        {

        }

        public int UserId { get; private set; }
        public int RoleId { get; private set; }

        public virtual User User { get; private set; }
        public virtual Role Role { get; private set; }

        public static UserRole GetInstance(int userId, int roleId, User user, Role role)
        {
            return new UserRole()
            {
                UserId = userId,
                RoleId = roleId,
                User = User.GetInstance(user.FirstName, user.LastName, user.Username, user.Password, null),
                Role = Role.GetInstance(role.Name, null)
            };
        }
    }
}
