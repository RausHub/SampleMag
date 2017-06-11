using SampleMag.Entity;
using System.Collections.Generic;
using System.Data.Entity;

namespace SampleMag.Data
{
    public class SampleMagInitializer : DropCreateDatabaseAlways<SampleMagContext>
    {        
        protected override void Seed(SampleMagContext context)
        {
            
        }
    }
}
