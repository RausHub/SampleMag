using SampleMag.Entity;

namespace SampleMag.Data.Configuration { 
    class VoteUserConfiguration : EntityBaseConfiguration<VoteUser>
    {
        public VoteUserConfiguration()
        {
            Property(ur => ur.UserId).IsRequired();
            Property(ur => ur.VoteID).IsRequired();
        }
    }
}
