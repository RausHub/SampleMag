using SampleMag.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Data.Configurations
{
    public class SampleConfiguration : EntityBaseConfiguration<Sample>
    {
        public SampleConfiguration()
        {
            Property(m => m.Title).IsRequired().HasMaxLength(100);
            Property(m => m.GenreId).IsRequired();
            Property(m => m.UserId).IsRequired();
            Property(m => m.UpVoteCount).IsRequired();
            Property(m => m.Text).IsRequired().HasMaxLength(2000);
            Property(m => m.TrailerURI).HasMaxLength(200);
        }
    }
}
