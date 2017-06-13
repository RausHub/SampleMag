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
            //  create genres
            context.GenreSet.AddOrUpdate(g => g.Name, GenerateGenres());

            // create Samples
            context.SampleSet.AddOrUpdate(m => m.Title, GenerateSamples());

            // create roles
            context.RoleSet.AddOrUpdate(r => r.Name, GenerateRoles());

            // username: jelle, password: homecinema
            context.UserSet.AddOrUpdate(u => u.Email, new User[]{
                new User()
                {
                    Email="jelle@gmail.com",
                    Username="jelle",
                    HashedPassword ="XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
                    IsLocked = false,
                    DateCreated = DateTime.Now
                }
            });

            // // create user-admin for chsakell
            context.UserRoleSet.AddOrUpdate(new UserRole[] {
                new UserRole() {
                    RoleId = 1, // admin
                    UserId = 1  // jelle
                }
            });
        }

        private Genre[] GenerateGenres()
        {
            Genre[] genres = new Genre[] {
                new Genre() { Name = "Alternative" },
                new Genre() { Name = "Electro" },
                new Genre() { Name = "Pop" },
                new Genre() { Name = "Hiphop" }
            };

            return genres;
        }
        private Sample[] GenerateSamples()
        {
            Sample[] Samples = new Sample[] {
                new Sample()
                {   Title="Minions", 
                    GenreId = 1, 
                    Producer="person x", 
                    PublishDate = new DateTime(2015, 7, 10), 
                    UpVoteCount = 2, 
                    Text = "Minions Stuart, Kevin and Bob are recruited by Scarlet Overkill, a super-villain who, alongside her inventor husband Herb, hatches a plot to take over the world.", 
                    TrailerURI = "https://www.youtube.com/watch?v=Wfql_DoHRKc" 
                },
                new Sample()
                {   Title="Ted 2", 
                    GenreId = 1, 
                    Producer="person y",
                    PublishDate = new DateTime(2015, 6, 27),
                    UpVoteCount = 7,
                    Text = "Newlywed couple Ted and Tami-Lynn want to have a baby, but in order to qualify to be a parent, Ted will have to prove he's a person in a court of law.", 
                    TrailerURI = "https://www.youtube.com/watch?v=S3AVcCggRnU" 
                },
                new Sample()
                {   Title="Trainwreck", 
                    GenreId = 2, 
                    Producer="person x",
                    PublishDate = new DateTime(2015, 7, 17),
                    UpVoteCount = 5,
                    Text = "Having thought that monogamy was never possible, a commitment-phobic career woman may have to face her fears when she meets a good guy.", 
                    TrailerURI = "https://www.youtube.com/watch?v=2MxnhBPoIx4" 
                },
                new Sample()
                {   Title="Inside Out", 
                    GenreId = 1, 
                    Producer="person x",
                    PublishDate = new DateTime(2015, 6, 19),
                    UpVoteCount = 9,
                    Text = "After young Riley is uprooted from her Midwest life and moved to San Francisco, her emotions - Joy, Fear, Anger, Disgust and Sadness - conflict on how best to navigate a new city, house, and school.", 
                    TrailerURI = "https://www.youtube.com/watch?v=seMwpP0yeu4" 
                },
                new Sample()
                {   Title="Home", 
                    GenreId = 1, 
                    Producer="person x",
                    PublishDate = new DateTime(2015, 5, 27),
                    UpVoteCount = 2,
                    Text = "Oh, an alien on the run from his own people, lands on Earth and makes friends with the adventurous Tip, who is on a quest of her own.", 
                    TrailerURI = "https://www.youtube.com/watch?v=MyqZf8LiWvM" 
                },
                new Sample()
                {   Title="Batman v Superman: Dawn of Justice", 
                    GenreId = 2, 
                    Producer="person x",
                    PublishDate = new DateTime(2015, 3, 25),
                    UpVoteCount = 2,
                    Text = "Fearing the actions of a god-like Super Hero left unchecked, Gotham City's own formidable, forceful vigilante takes on Metropolis most revered, modern-day savior, while the world wrestles with what sort of hero it really needs. And with Batman and Superman at war with one another, a new threat quickly arises, putting mankind in greater danger than it's ever known before.", 
                    TrailerURI = "https://www.youtube.com/watch?v=0WWzgGyAH6Y" 
                },
                new Sample()
                {   Title="Ant-Man", 
                    GenreId = 2, 
                    Producer="person a",
                    PublishDate = new DateTime(2015, 7, 17),
                    UpVoteCount = 2,
                    Text = "Armed with a super-suit with the astonishing ability to shrink in scale but increase in strength, cat burglar Scott Lang must embrace his inner hero and help his mentor, Dr. Hank Pym, plan and pull off a heist that will save the world.", 
                    TrailerURI = "https://www.youtube.com/watch?v=1HpZevFifuo" 
                },
                new Sample()
                {   Title="Jurassic World", 
                    GenreId = 2, 
                    Producer="person a",
                    PublishDate = new DateTime(2015, 6, 12),
                    UpVoteCount = 2,
                    Text = "A new theme park is built on the original site of Jurassic Park. Everything is going well until the park's newest attraction--a genetically modified giant stealth killing machine--escapes containment and goes on a killing spree.", 
                    TrailerURI = "https://www.youtube.com/watch?v=RFinNxS5KN4" 
                },
                new Sample()
                {   Title="Fantastic Four", 
                    GenreId = 2, 
                    Producer="person a",
                    PublishDate = new DateTime(2015, 8, 7),
                    UpVoteCount = 2,
                    Text = "Four young outsiders teleport to an alternate and dangerous universe which alters their physical form in shocking ways. The four must learn to harness their new abilities and work together to save Earth from a former friend turned enemy.", 
                    TrailerURI = "https://www.youtube.com/watch?v=AAgnQdiZFsQ" 
                },
                new Sample()
                {   Title="Mad Max: Fury Road", 
                    GenreId = 2, 
                    Producer="person a",
                    PublishDate = new DateTime(2015, 5, 15),
                    UpVoteCount = 2,
                    Text = "In a stark desert landscape where humanity is broken, two rebels just might be able to restore order: Max, a man of action and of few words, and Furiosa, a woman of action who is looking to make it back to her childhood homeland.", 
                    TrailerURI = "https://www.youtube.com/watch?v=hEJnMQG9ev8" 
                },
                new Sample()
                {   Title="True Detective", 
                    GenreId = 3, 
                    Producer="person a",
                    PublishDate = new DateTime(2015, 5, 15),
                    UpVoteCount = 2,
                    Text = "An anthology series in which police investigations unearth the personal and professional secrets of those involved, both within and outside the law.", 
                    TrailerURI = "https://www.youtube.com/watch?v=TXwCoNwBSkQ" 
                },
                new Sample()
                {   Title="The Longest Ride", 
                    GenreId = 4, 
                    Producer="person a",
                    PublishDate = new DateTime(2015, 5, 15),
                    UpVoteCount = 2,
                    Text = "After an automobile crash, the lives of a young couple intertwine with a much older man, as he reflects back on a past love.", 
                    TrailerURI = "https://www.youtube.com/watch?v=FUS_Q7FsfqU" 
                },
                new Sample()
                {   Title="The Walking Dead", 
                    GenreId = 4, 
                    Producer="person a",
                    PublishDate = new DateTime(2015, 3, 28),
                    UpVoteCount = 2,
                    Text = "Sheriff's Deputy Rick Grimes leads a group of survivors in a world overrun by zombies.", 
                    TrailerURI = "https://www.youtube.com/watch?v=R1v0uFms68U" 
                },
                new Sample()
                {   Title="Southpaw", 
                    GenreId = 3, 
                    Producer="person a",
                    PublishDate = new DateTime(2015, 8, 17),
                    UpVoteCount = 2,
                    Text = "Boxer Billy Hope turns to trainer Tick Willis to help him get his life back on track after losing his wife in a tragic accident and his daughter to child protection services.", 
                    TrailerURI = "https://www.youtube.com/watch?v=Mh2ebPxhoLs" 
                },
                new Sample()
                {   Title="Specter", 
                    GenreId = 3, 
                    Producer="person a",
                    PublishDate = new DateTime(2015, 11, 5),
                    UpVoteCount = 2,
                    Text = "A cryptic message from Bond's past sends him on a trail to uncover a sinister organization. While M battles political forces to keep the secret service alive, Bond peels back the layers of deceit to reveal the terrible truth behind SPECTRE.", 
                    TrailerURI = "https://www.youtube.com/watch?v=LTDaET-JweU" 
                },
            };

            return Samples;
        }
        
        private Role[] GenerateRoles()
        {
            Role[] _roles = new Role[]{
                new Role()
                {
                    Name="Admin"
                }
            };

            return _roles;
        }        
    }
}
