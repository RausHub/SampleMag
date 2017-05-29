using SampleMag.Entity;

namespace SampleMag.Data
{
    public class LifetimeConfiguration : EntityBaseConfiguration<Lifetime>
    {
        public LifetimeConfiguration()
        {
            Property(l => l.Name).IsRequired().HasMaxLength(100);
            Property(l => l.Duration).IsRequired();
        }
    }
}
