using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Entity
{
    public abstract class UserBase : IEntityBase
    {
        public UserBase()
        {
            UserRoles = new List<UserRole>();
        }

        public long ID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public bool IsLocked { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
