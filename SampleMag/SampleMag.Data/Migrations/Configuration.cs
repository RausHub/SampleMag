namespace SampleMag.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SampleMag.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<SampleMagContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SampleMagContext context)
        {
            ////create some languages
            ////werken en zijn independent
            //context.LanguageSet.Add(new Language() { Name = "English" });
            //context.LanguageSet.Add(new Language() { Name = "Nederlands" });

            ////create some Lifetime
            ////werken en zijn independent
            //context.LifetimeSet.Add(new Lifetime()
            //{
            //    Name = "1 Year",
            //    Duration = 365
            //});
            //context.LifetimeSet.Add(new Lifetime()
            //{
            //    Name = "1 Month",
            //    Duration = 30
            //});

            ////create some Music_genres
            //context.MusicGenreSet.Add(new Music_Genre() { Name = "Alternative" });
            //context.MusicGenreSet.Add(new Music_Genre() { Name = "Electronic" });
            //context.MusicGenreSet.Add(new Music_Genre() { Name = "Hiphop" });
            //context.MusicGenreSet.Add(new Music_Genre() { Name = "Pop" });

            ////create some Profile_Status
            //context.ProfileStatusSet.Add(new ProfileStatus() { Name = "Normal" });
            //context.ProfileStatusSet.Add(new ProfileStatus() { Name = "Regular" });

            ////create some Role
            //context.RoleSet.Add(new Role() { Name = "Admin" });

            ////create some Users
            //context.UserSet.Add( //pass = homecinema
            //    new User()
            //    {
            //        City = "Turnhout",
            //        Country = "Belgium",
            //        Email = "rausjelle@hotmail.com",
            //        DateCreated = DateTime.Now,
            //        First_Name = "Jelle",
            //        HashedPassword = "XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
            //        Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
            //        IsLocked = false,
            //        Language_Preference_ID = 1,
            //        Last_Name = "Raus",
            //        Profile_Name = "Jelle",
            //        Username = "Jelle",
            //        Vote_Count_Up = 2,
            //    });

            //create some Samples
            //context.SampleSet.Add(new Sample()
            //{
            //    Content_Path = "https://www.youtube.com/watch?v=31YqCWEyPsg",
            //    Count_Up = 10,
            //    GenreID = 1,
            //    Count_Down = 0,
            //    LifeTimeID = 1,
            //    Location = "Turnhout",
            //    Posted_On = DateTime.Now,
            //    Text = "Geniet van deze plaat",
            //    Title = "Relax with Opeth",
            //    UserID = 1
            //});
            //context.SampleSet.Add(new Sample()
            //{
            //    Content_Path = "https://www.youtube.com/watch?v=XBYgwiGUsKc",
            //    Count_Up = 5,
            //    GenreID = 1,
            //    Count_Down = 0,
            //    LifeTimeID = 1,
            //    Location = "Turnhout",
            //    Posted_On = DateTime.Now,
            //    Text = "Psychedelic good",
            //    Title = "Drugs plaat",
            //    UserID = 1
            //});

            //create new user role
            //context.UserRoleSet.Add(new UserRole()
            //{
            //    RoleId = 1,
            //    UserId = 1
            //});

            ////create some user_types
            //context.UserTypeSet.Add(new User_Type() { Name = "Musician" });
            //context.UserTypeSet.Add(new User_Type() { Name = "Director" });

            //create some votes
            //context.VoteSet.Add(new Vote()
            //{
            //    SampleId = 1,
            //    Time_Of_Vote = DateTime.Now,
            //    Vote_Value = 1,
            //    Remark = "nie slecht dedju"
            //});
            //context.VoteSet.Add(new Vote()
            //{
            //    SampleId = 2,
            //    Time_Of_Vote = DateTime.Now,
            //    Vote_Value = 0,
            //    Remark = "matig"
            //});

            //create some vote user
            //context.VoteUserSet.Add(new VoteUser()
            //{
            //    UserId = 1,
            //    VoteID = 1,
            //});
            //context.VoteUserSet.Add(new VoteUser()
            //{
            //    UserId = 1,
            //    VoteID = 2
            //});

            //base.Seed(context);
        }
    }
}
