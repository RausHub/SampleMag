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
            //create some languages
            context.LanguageSet.AddOrUpdate(g => g.Name, new Language[]{
                new Language()
                {
                    Name="English"
                },
                new Language()
                {
                    Name="Nederlands"
                }
            });

            //create some Lifetime
            context.LifetimeSet.AddOrUpdate(g => g.Name, new Lifetime[]
            {
                new Lifetime()
                {
                    Name = "1 Year",
                    Duration = new TimeSpan(365,0,0,0)
                },
                new Lifetime()
                {
                    Name = "1 Month",
                    Duration = new TimeSpan(30,0,0,0)
                }
            });

            //create some Music_genres
            context.MusicGenreSet.AddOrUpdate(g => g.Name, new Music_Genre[]
            {
                new Music_Genre() {Name="Alternative"},
                new Music_Genre() {Name="Electronic"},
                new Music_Genre() {Name="Hiphop"},
                new Music_Genre() {Name="Pop"}
            });

            //create some Profile_Status
            context.ProfileStatusSet.AddOrUpdate(g => g.Name, new ProfileStatus[]
            {
                new ProfileStatus(){Name="Normal"},
                new ProfileStatus(){Name="Regular"},
            });

            //create some Role
            context.RoleSet.AddOrUpdate(g => g.Name, new Role[]
            {
                new Role() {Name="Admin"}
            });

            //create some Samples
            context.SampleSet.AddOrUpdate(g => g.Title, new Sample[]
            {
                new Sample()
                {
                    Content_Path = "https://www.youtube.com/watch?v=31YqCWEyPsg",
                    Count_Up = 10,
                    GenreID = 1,
                    Count_Down = 0,
                    LifeTimeID = 1,
                    Location = "Turnhout",
                    Posted_On = DateTime.Now,
                    Text = "Geniet van deze plaat",
                    Title = "Relax with Opeth",
                    UserID = 1
                },
                new Sample()
                {
                    Content_Path = "https://www.youtube.com/watch?v=XBYgwiGUsKc",
                    Count_Up = 5,
                    GenreID = 1,
                    Count_Down = 0,
                    LifeTimeID = 1,
                    Location = "Turnhout",
                    Posted_On = DateTime.Now,
                    Text = "Psychedelic good",
                    Title = "Drugs plaat",
                    UserID = 1
                }
            });

            //create some Users
            context.UserSet.AddOrUpdate(g => g.Username, new User[]
            {
                //pass = homecinema
                new User()
                {
                    City = "Turnhout",
                    Country = "Belgium",
                    Email = "rausjelle@hotmail.com",
                    DateCreated = DateTime.Now.AddMonths(-1),
                    First_Name ="Jelle",
                    HashedPassword = "XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
                    IsLocked = false,
                    Language_Preference_ID = 1,
                    Last_Name = "Raus",
                    Profile_Name = "Jelle",
                    Username = "Jelle",
                    Vote_Count_Up = 2,
                }
            });

            //create new user role
            context.UserRoleSet.AddOrUpdate(new UserRole[]
            {
                new UserRole()
                {
                    RoleId=1,
                    UserId=1
                }
            });

            //create some user_types
            context.UserTypeSet.AddOrUpdate(new User_Type[]
            {
                new User_Type() { Name = "Musician" },
                new User_Type() { Name = "Director" }
            });

            //create some vote user
            context.VoteUserSet.AddOrUpdate(new VoteUser[]
            {
                new VoteUser()
                {
                    UserId = 1,
                    VoteID = 1,
                },
                new VoteUser()
                {
                    UserId = 1,
                    VoteID =2
                }
            });

            //create some votes
            context.VoteSet.AddOrUpdate(new Vote[]
            {
                new Vote()
                {
                    SampleId = 1,
                    Time_Of_Vote = DateTime.Now,
                    Vote_Value = 1,
                    Remark = "nie slecht dedju"
                },
                new Vote()
                {
                    SampleId = 2,
                    Time_Of_Vote = DateTime.Now,
                    Vote_Value = 0,
                    Remark = "matig"
                }
            });
        }
    }
}
