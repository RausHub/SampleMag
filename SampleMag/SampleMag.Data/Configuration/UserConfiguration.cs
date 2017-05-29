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
            Property(u => u.DateCreated);
            Property(u => u.Email).IsRequired().HasMaxLength(200);
            Property(u => u.Profile_Name);
            Property(u => u.First_Name);
            Property(u => u.Last_Name);
            Property(u => u.City);
            Property(u => u.Country);
            Property(u => u.Phone);
            Property(u => u.Language_Preference_ID);
            Property(u => u.Timezone);
            Property(u => u.Profile_Picture);
            Property(u => u.User_Bio);
            Property(u => u.Profile_Name);
            Property(u => u.Url);
            Property(u => u.User_Status_ID);
            Property(u => u.User_Type_ID);
            HasMany(u => u.User_Categories);
            Property(u => u.Vote_Count_Down);
            Property(u => u.Vote_Count_Up);
            HasMany(u => u.Votes).WithRequired().HasForeignKey(v => v.UserId);
        }
    }
}
