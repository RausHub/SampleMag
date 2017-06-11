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
            Property(s => s.GenreID).IsRequired();
            Property(s => s.Posted_On).IsRequired();
            Property(s => s.LifeTimeID).IsRequired();
            Property(s => s.Last_Update).IsOptional();
            Property(s => s.Title).IsRequired().HasMaxLength(100);
            Property(s => s.Text).IsRequired();
            Property(s => s.Content_Path).IsOptional();
            Property(s => s.Url).IsOptional();
            Property(s => s.Location).IsOptional();
            Property(s => s.Meta_Value).IsOptional();
            Property(s => s.Count_Down).IsOptional();
            Property(s => s.Count_Up).IsOptional();
            Property(s => s.Mother_ID).IsOptional();
        }
    }
}
