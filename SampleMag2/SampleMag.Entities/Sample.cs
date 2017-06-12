using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Entities
{
    public class Sample : IEntityBase
    {        
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public string Producer { get; set; }
        public DateTime PublishDate { get; set; }
        public byte Rating { get; set; }
        public string TrailerURI { get; set; }
    }
}
