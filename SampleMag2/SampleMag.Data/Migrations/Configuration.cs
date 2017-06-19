namespace SampleMag.Data.Migrations
{
    using SampleMag.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SampleMagContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SampleMagContext context)
        {
            // username: jelle, password: homecinema
            context.UserSet.AddOrUpdate(u => u.Email, GenerateUser());

            //  create genres
            context.GenreSet.AddOrUpdate(g => g.Name, GenerateGenres());

            // create Samples
            context.SampleSet.AddOrUpdate(m => m.Title, GenerateSamples());

            // create roles
            context.RoleSet.AddOrUpdate(r => r.Name, GenerateRoles());

            // // create user-admin for chsakell
            context.UserRoleSet.AddOrUpdate(new UserRole[] {
                new UserRole() {
                    RoleId = 1, // admin
                    UserId = 1  // jelle
                },
                new UserRole() {
                    RoleId = 1, // admin
                    UserId = 2  // swa
                }
            });
        }

        private User[] GenerateUser()
        {
            User[] users = new User[]
            {
                new User()
                {
                    ID = 1,
                    Email="jelle@gmail.com",
                    Username="jelle",
                    HashedPassword ="TwELUUfnnt4mqzfH/vXkO0onlhoPHN+bxNT0mDdTUz4=",
                    Salt = "AwnWlGPlxL0+MHnmcHd6lQ==",
                    IsLocked = false,
                    DateCreated = DateTime.Now
                },
                new User()
                {
                    ID = 2,
                    Email="swa@gmail.com",
                    Username="swa",
                    HashedPassword ="TwELUUfnnt4mqzfH/vXkO0onlhoPHN+bxNT0mDdTUz4=",
                    Salt = "AwnWlGPlxL0+MHnmcHd6lQ==",
                    IsLocked = false,
                    DateCreated = DateTime.Now
                }
            };

            return users;
        }
        private Genre[] GenerateGenres()
        {
            Genre[] genres = new Genre[] {
                new Genre() { ID = 1, Name = "Alternative" },
                new Genre() { ID = 2, Name = "Electro" },
                new Genre() { ID = 3, Name = "Pop" },
                new Genre() { ID = 4, Name = "Hiphop" }
            };

            return genres;
        }
        private Sample[] GenerateSamples()
        {
            Sample[] Samples = new Sample[] {
                new Sample()
                {   Title="Minimal House Running",
                    GenreId = 2,
                    UserId = 1,
                    PublishDate = new DateTime(2017, 6, 10),
                    UpVoteCount = 2,
                    Text = "Best Music charts: Gaming Music, Coronita, New Best Club Dance Festival Music Remixes, Workout Music, EDM minimal, Electro house, Car Music, Future Partymusik",
                    TrailerURI = "https://www.youtube.com/watch?v=Vfbl7snaLZw"
                },
                new Sample()
                {   Title="Droplex",
                    GenreId = 2,
                    UserId = 2,
                    PublishDate = new DateTime(2017, 6, 17),
                    UpVoteCount = 7,
                    Text = "Best Music charts: Weed Minimal Tecnho Gaming Music, Coronita, New Best Club Dance Festival Music Remixes, Workout Music, EDM minimal, Car Music, Future Partymusik",
                    TrailerURI = "https://www.youtube.com/watch?v=kVdDYd67WNs&t=1954s"
                },
                new Sample()
                {   Title="The Dead South",
                    GenreId = 1,
                    UserId = 1,
                    PublishDate = new DateTime(2017, 6, 16),
                    UpVoteCount = 5,
                    Text = "Directed by Zach Wilson of Two Brothers Films. We recognize and thank Creative Saskatchewan for their financial support in the production of this video.",
                    TrailerURI = "https://www.youtube.com/watch?v=B9FzVhw8_bY"
                },
                new Sample()
                {   Title="Thunderstruck by Steve'n'Seagulls",
                    GenreId = 1,
                    UserId = 2,
                    PublishDate = new DateTime(2017, 6, 19),
                    UpVoteCount = 9,
                    Text = "Finnish band called Steve'n'Seagulls plays AC/DC's awesome song called Thunderstruck. Recorded by Jaakko Manninen Photography. TOUR DATES HERE: www.stevenseagulls.com / gigs",
                    TrailerURI = "https://www.youtube.com/watch?v=e4Ao-iNPPUc"
                },
                new Sample()
                {   Title="Blue October - Hate Me",
                    GenreId = 1,
                    UserId = 2,
                    PublishDate = new DateTime(2017, 5, 27),
                    UpVoteCount = 2,
                    Text = "Music video by Blue October performing Hate Me (10th Anniversary) [Live]. (C) 2015 Up Down Records",
                    TrailerURI = "https://www.youtube.com/watch?v=Y3F3AcnGFWw"
                },
                new Sample()
                {   Title="Best Of EDM Mix",
                    GenreId = 2,
                    UserId = 1,
                    PublishDate = new DateTime(2017, 3, 25),
                    UpVoteCount = 2,
                    Text = "More Free Music: http://goo.gl/hUpPJV - Watch Volume 3 from this Video: https://youtu.be/l2yNR3ZUFw0 - Watch Volume 2 from this Video: https://youtu.be/0_ltN44SfRU - Watch Volume 1 from this Video: https://youtu.be/_B789lus-JE",
                    TrailerURI = "https://www.youtube.com/watch?v=_B789lus-JE"
                },
                new Sample()
                {   Title="BEST ELECTRO HOUSE BASS ",
                    GenreId = 2,
                    UserId = 1,
                    PublishDate = new DateTime(2017, 5, 17),
                    UpVoteCount = 2,
                    Text = "BASS BOOSTED MUSIC 2017 BEST ELECTRO HOUSE BASS & BOUNCE TRAP MIX 2017 | Car Music Mix 2017 | Festival Mix 2017 | TRAP MUSIC 2017 | Best Of EDM. Support me: Youtube ? http://bit.ly/1WEUJtV Like my Facebook Page ? https://www.facebook.com/DJTecknoboy",
                    TrailerURI = "https://www.youtube.com/watch?v=dGk5Fx5MwgU"
                },
                new Sample()
                {   Title="TRAP MUSIC 2017",
                    GenreId = 2,
                    UserId = 1,
                    PublishDate = new DateTime(2017, 6, 12),
                    UpVoteCount = 2,
                    Text = "Magic Music on Facebook: https://fb.me/magicmusicsquad",
                    TrailerURI = "https://www.youtube.com/watch?v=d3ggCpV2ff0"
                },
                new Sample()
                {   Title="Minimal Techno (March 2017)",
                    GenreId = 2,
                    UserId = 2,
                    PublishDate = new DateTime(2017, 4, 7),
                    UpVoteCount = 2,
                    Text = "1. 00:00 Chris Lawyer - Right On Time (Original Uncut Mix); 2. 02:58 Eminem - Without - Me(Semperger G Remix); 3. 05:48 ZHU - Faded(DOUB Remix); 4. 12:03 Droplex - Killa Kokain(Original mix); 5. 13:38 Droplex - Psychological Attack(Original Mix)"+
                        "; 6. 16:19 Droplex & Breech - Brain Crackin(Original Mix); 7. 20:34 Duane Bartolo -Good For YOU(Minimal Men Remix); 8. 24:50 Cosmonov - Black Magic 2016(Original Mix); 9. 30:36 Eiffel 65 - Blue(Dani Row Private Remix)"+
                        "; 10. 34:10 Jus Deelax -Baileys(Original Mix); 11. 38:40 Oriol Carrio, Jus Deelax - Tetris 2014(Extended Mix); 12. 42:55 Kalus - Fuck Off & Die(Tommy Salter Remix); 13. 47:25 Danny Darko &Jova Radevska - Time Will Tell(Droplex Remix)",
                    TrailerURI = "https://www.youtube.com/watch?v=A-Dnu5UaEVc"
                },
                new Sample()
                {   Title="Deep House (2017)",
                    GenreId = 2,
                    UserId = 2,
                    PublishDate = new DateTime(2017, 5, 15),
                    UpVoteCount = 2,
                    Text = "All the tracks and image art used in our video are the property of their respective owners. No copyright infringement intended strictly for promotional use. Will remove if requested by record labels.",
                    TrailerURI = "https://www.youtube.com/watch?v=1nQ6-HHUNAo"
                },
                new Sample()
                {   Title="Jason Derulo - Swalla (feat. Nicki Minaj & Ty Dolla $ign)",
                    GenreId = 3,
                    UserId = 1,
                    PublishDate = new DateTime(2017, 5, 15),
                    UpVoteCount = 2,
                    Text = "Official Music video for 'Swalla' - directed by Gil Green Buy or Stream now! http://wbr.lnk.to/swalla",
                    TrailerURI = "https://www.youtube.com/watch?v=NGLxoKOvzu4"
                },
                new Sample()
                {   Title="The Notorious B.I.G. - Big Poppa",
                    GenreId = 4,
                    UserId = 1,
                    PublishDate = new DateTime(2017, 5, 18),
                    UpVoteCount = 2,
                    Text = "Big Poppa by The Notorious B.I.G. From The Notorious B.I.G. album Ready To Die (1994).",
                    TrailerURI = "https://www.youtube.com/watch?v=phaJXp_zMYM"
                },
                new Sample()
                {   Title="2pac feat Dr.Dre - California Love",
                    GenreId = 4,
                    UserId = 1,
                    PublishDate = new DateTime(2017, 6, 2),
                    UpVoteCount = 2,
                    Text = "Let's show these fools how we do it on this on that west side. Cause you and I know it's the best side. Yea that's right, west coast we coast, Uh California love, California love",
                    TrailerURI = "https://www.youtube.com/watch?v=5wBTdfAkqGU"
                },
                new Sample()
                {   Title="Justin Bieber - What Do You Mean?",
                    GenreId = 3,
                    UserId = 2,
                    PublishDate = new DateTime(2017, 4, 27),
                    UpVoteCount = 2,
                    Text = "‘Purpose’ Available Everywhere Now! iTunes: http://smarturl.it/PurposeDlx?IQid=VE... Add To Your Spotify Playlist: http://smarturl.it/sPurpose?IQid=VEVO... Google Play: http://smarturl.it/gPurpose?IQid=VEVO..."+
                        "Amazon: http://smarturl.it/aPurpose?IQid=VEVO... ",
                    TrailerURI = "https://www.youtube.com/watch?v=DK_0jXPuIr0"
                },
                new Sample()
                {   Title="Kygo, Martin Garrix ft. Sia - Our Time",
                    GenreId = 3,
                    UserId = 1,
                    PublishDate = new DateTime(2017, 6, 5),
                    UpVoteCount = 2,
                    Text = "Kygo, The Chainsmokers, Martin Garrix ft. Selena Gomez - Best Deep House Music Mix 2017 Remixes & Chillout Songs",
                    TrailerURI = "https://www.youtube.com/watch?v=3FiH9K9F2U0"
                },
            };

            return Samples;
        }
        private Role[] GenerateRoles()
        {
            Role[] _roles = new Role[]{
                new Role()
                {
                    Name="User"
                }
            };

            return _roles;
        }
    }
}
