using SampleMag.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Data.Configuration
{
    public class SampleConfiguration :EntityBaseConfiguration<Sample>
    {
        public SampleConfiguration()
        {
            Property(s => s.UserID).IsRequired();
            HasMany(s => s.Genres);
            Property(s => s.Posted_On).IsRequired();
            Property(s => s.LifeTimeID).IsRequired();
            Property(s => s.Last_Update).IsOptional();
            Property(s => s.Title).IsRequired().HasMaxLength(100);
            Property(s => s.Text).IsRequired();
            Property(s => s.Content_Path);
            Property(s => s.Url);
            Property(s => s.Location);
            Property(s => s.Meta_Value);
            Property(s => s.Count_Down);
            Property(s => s.Count_Up);
            Property(s => s.Mother_ID).IsOptional();
        }
    }
}
