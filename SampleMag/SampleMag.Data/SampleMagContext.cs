using SampleMag.Data.Configuration;
using SampleMag.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SampleMag.Data
{
    public class SampleMagContext : DbContext
    {
        public SampleMagContext() : base("SampleMagConnection")
        {
            //Database.SetInitializer<SampleMagContext>(null);
            Database.SetInitializer(new SampleMagInitializer());
        }

        #region Entity Sets
        public IDbSet<Language> LanguageSet { get; set; }
        public IDbSet<Lifetime> LifetimeSet { get; set; }
        public IDbSet<Music_Genre> MusicGenreSet { get; set; }
        public IDbSet<ProfileStatus> ProfileStatusSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        public IDbSet<Sample> SampleSet { get; set; }
        public IDbSet<User> UserSet { get; set; }
        public IDbSet<UserRole> UserRoleSet { get; set; }
        public IDbSet<User_Type> UserTypeSet { get; set; }
        public IDbSet<Vote> VoteSet { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }
        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new LanguageConfiguration());
            modelBuilder.Configurations.Add(new LifetimeConfiguration());
            modelBuilder.Configurations.Add(new MusicGenreConfiguration());
            modelBuilder.Configurations.Add(new ProfileStatusConfiguration());
            modelBuilder.Configurations.Add(new SampleConfiguration());
            modelBuilder.Configurations.Add(new UserTypeConfiguration());
            modelBuilder.Configurations.Add(new VoteConfiguration());
        }
    }
}
