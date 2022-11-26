using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartAssessment.Domain.Entities
{
    public class Role : EntityBase
    {
        private Role()
        {
        }

        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; private set; }


        public static Role GetInstance(string name, List<UserRole> userRoles = null)
        {
            return new Role()
            {
                Name = name,
                UserRoles = userRoles
            };
        }
    }
}
