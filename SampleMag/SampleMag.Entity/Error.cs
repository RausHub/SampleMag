using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Entity
{
    public class Error : IEntityBase
    {
        public long ID { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
