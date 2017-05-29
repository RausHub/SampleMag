using System.Collections.Generic;
using System.Linq;
using Music.Models.Mapper;
using Music.EF;


namespace Music.Models.Service
{
    public class UserService
    {
        protected static readonly SampleMagDatabaseEntities ef = new SampleMagDatabaseEntities();

        public static User GetUser(int id)
        {
            ef.Configuration.LazyLoadingEnabled = false;
            return ef.User.Where(x => x.Id == id).FirstOrDefault();
        }

        public static List<User> GetAll()
        {
            ef.Configuration.LazyLoadingEnabled = false;
            return ef.User.ToList();
        }

        public static void Create(User u)
        {
            ef.User.Add(u);
            ef.SaveChanges();
        }

        public static void Update(User u)
        {
            var temp = ef.User.Where(x => x.Id == u.Id).FirstOrDefault();
            UserMapper.CloneUser(ref temp, u);
            ef.SaveChanges();
        }

        public static void Delete(User u)
        {
            var temp = ef.User.Where(x => x.Id == u.Id).FirstOrDefault();
            ef.User.Remove(temp);
            ef.SaveChanges();
        }
    }
}