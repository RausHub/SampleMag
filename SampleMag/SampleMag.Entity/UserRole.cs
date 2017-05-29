using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Entity
{
    public class UserRole : IEntityBase
    {
        public long ID { get; set; }

        public long UserId { get; set; }

        public long RoleId { get; set; }

        public Role Role { get; set; }
    }
}
