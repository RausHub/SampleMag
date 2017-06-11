using SampleMag.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Data.Configuration
{
    public class VoteConfiguration : EntityBaseConfiguration<Vote>
    {
        public VoteConfiguration()
        {
            Property(v => v.SampleId).IsRequired();
            Property(v => v.Vote_Value).IsRequired();
            Property(v => v.Remark).IsOptional();
            Property(v => v.Time_Of_Vote).IsRequired();
        }
    }
}
