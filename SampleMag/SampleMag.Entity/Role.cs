using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Entity
{
    public class Role : IEntityBase
    {
        public long ID { get; set; }

        public string Name { get; set; }
    }
}
