using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Entity
{
     public class VoteUser : IEntityBase
    {
        public long ID { get; set; }

        public long UserId { get; set; }

        public long VoteID { get; set; }
    }
}
