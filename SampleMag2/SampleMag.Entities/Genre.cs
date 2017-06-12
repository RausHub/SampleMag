using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Entities
{
    /// <summary>
    /// SampleMag Sample Genre
    /// </summary>
    public class Genre : IEntityBase
    {
        public Genre()
        {
            Samples = new List<Sample>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Sample> Samples { get; set; }
    }
}
