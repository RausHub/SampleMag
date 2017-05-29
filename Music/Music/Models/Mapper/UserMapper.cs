using Music.EF;

namespace Music.Models.Mapper
{
    public class UserMapper
    {
        public static void CloneUser(ref User u, User temp)
        {
            u.City = temp.City;
            u.Country = temp.Country;
            u.DateCreated = temp.DateCreated;
            u.Email = temp.Email;
            u.First_Name = temp.First_Name;
            u.IsLocked = temp.IsLocked;
            u.Language_Preference_ID = temp.Language_Preference_ID;
            u.Last_Name = temp.Last_Name;
            u.Phone = temp.Phone;
            u.Profile_Name = temp.Profile_Name;
            u.Profile_Picture = temp.Profile_Picture;
            u.Timezone = temp.Timezone;
            u.Url = temp.Url;
            u.Username = temp.Username;
            u.User_Bio = temp.User_Bio;
            u.User_Status_ID = temp.User_Status_ID;
            u.User_Type_ID = temp.User_Type_ID;
        }
    }
}