using SampleMag.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Data.Configuration
{
    public class UserTypeConfiguration : EntityBaseConfiguration<User_Type>
    {
        public UserTypeConfiguration()
        {
            Property(u => u.Name).IsRequired().HasMaxLength(100);
        }
    }
}
