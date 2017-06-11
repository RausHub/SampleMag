using SampleMag.Entity;

namespace SampleMag.Data.Configuration
{
    class UserMusicGenreConfiguration : EntityBaseConfiguration<User_MusicGenre>
    {
        public UserMusicGenreConfiguration()
        {
            Property(ur => ur.UserId).IsRequired();
            Property(ur => ur.MusicGenreId).IsRequired();
        }
    }
}
