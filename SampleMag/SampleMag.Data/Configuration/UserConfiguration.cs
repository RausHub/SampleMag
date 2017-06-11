using SampleMag.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Data.Configuration
{
    public class UserConfiguration : EntityBaseConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.Username).IsRequired().HasMaxLength(100);
            Property(u => u.Email).IsRequired().HasMaxLength(200);
            Property(u => u.HashedPassword).IsRequired().HasMaxLength(200);
            Property(u => u.Salt).IsRequired().HasMaxLength(200);
            Property(u => u.IsLocked).IsRequired();
            Property(u => u.DateCreated).IsOptional();
            Property(u => u.Email).IsRequired().HasMaxLength(200);
            Property(u => u.Profile_Name).IsOptional();
            Property(u => u.First_Name).IsOptional();
            Property(u => u.Last_Name).IsOptional();
            Property(u => u.City).IsOptional();
            Property(u => u.Country).IsOptional();
            Property(u => u.Phone).IsOptional();
            Property(u => u.Language_Preference_ID).IsOptional();
            Property(u => u.Timezone).IsOptional();
            Property(u => u.Profile_Picture).IsOptional();
            Property(u => u.User_Bio).IsOptional();
            Property(u => u.Profile_Name).IsOptional();
            Property(u => u.Url).IsOptional();
            Property(u => u.User_Status_ID).IsOptional();
            Property(u => u.User_Type_ID).IsOptional();
            Property(u => u.Vote_Count_Down).IsOptional();
            Property(u => u.Vote_Count_Up).IsOptional();
        }
    }
}
