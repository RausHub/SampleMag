using SampleMag.Entity;
using System.Data.Entity.ModelConfiguration;

namespace SampleMag.Data
{    
    public class EntityBaseConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntityBase
    {
        public EntityBaseConfiguration()
        {
            HasKey(e => e.ID);
        }
    }
}
