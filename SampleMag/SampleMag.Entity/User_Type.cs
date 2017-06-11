using System;
using System.Collections.Generic;
using System.Text;

namespace SampleMag.Entity
{
    public class User_Type:IEntityBase
    {
        public User_Type()
        {
            
        }

        public long ID { get; set; }

        public string  Name { get; set; }
        
    }
}
