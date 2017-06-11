using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Entity
{
    public class User_MusicGenre : IEntityBase
    {
        public long ID { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public long MusicGenreId { get; set; }

        public Music_Genre MusicGenre { get; set; }
    }
}
