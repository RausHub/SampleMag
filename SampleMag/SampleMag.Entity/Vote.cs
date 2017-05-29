using System;
using System.Collections.Generic;
using System.Text;

namespace SampleMag.Entity
{
    public class Vote : IEntityBase
    {
        public long ID { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public long SampleId { get; set; }

        public Sample Sample { get; set; }

        public int Vote_Value { get; set; }

        public string Remark { get; set; }

        public DateTime Time_Of_Vote { get; set; }

    }
}
