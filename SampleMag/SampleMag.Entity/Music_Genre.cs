using System;
using System.Collections.Generic;
using System.Text;

namespace SampleMag.Entity
{
    public class Music_Genre : IEntityBase
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
