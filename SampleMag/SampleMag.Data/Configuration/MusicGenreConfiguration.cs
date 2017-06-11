using SampleMag.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Data.Configuration
{
    public class MusicGenreConfiguration : EntityBaseConfiguration<Music_Genre>
    {
        public MusicGenreConfiguration()
        {
            Property(m => m.Name).IsRequired().HasMaxLength(100);
            Property(m => m.Description).IsOptional();
        }
    }
}
