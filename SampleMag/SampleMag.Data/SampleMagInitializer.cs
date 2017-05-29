using SampleMag.Entity;
using System.Collections.Generic;
using System.Data.Entity;

namespace SampleMag.Data
{
    public class SampleMagInitializer : DropCreateDatabaseAlways<SampleMagContext>
    {
        
        protected override void Seed(SampleMagContext context)
        {
            IList<Sample> defaultSamples = new List<Sample>();
            defaultSamples.Add(new Sample { ID = 1, Title = "Test" });

            foreach (Sample s in defaultSamples)
            {
                context.SampleSet.Add(s);
                base.Seed(context);
            }
        }
    }
}
