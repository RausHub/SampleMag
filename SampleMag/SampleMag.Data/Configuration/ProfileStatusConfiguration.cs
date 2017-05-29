using SampleMag.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Data.Configuration
{
    public class ProfileStatusConfiguration : EntityBaseConfiguration<ProfileStatus>
    {
        public ProfileStatusConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(100);
        }
    }
}
