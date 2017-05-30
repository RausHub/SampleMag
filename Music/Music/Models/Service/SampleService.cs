using Music.Models.Mapper;
using Music.EF;
using System.Collections.Generic;
using System.Linq;

namespace Music.Models.Service
{
    public class SampleService
    {
        protected static readonly SampleMagDatabaseEntities ef = new SampleMagDatabaseEntities();

        public static Sample GetSample(int id)
        {
            ef.Configuration.LazyLoadingEnabled = false;
            var s = ef.Sample.Where(x => x.Id == id).FirstOrDefault();
            if (s != null & s.UserID > 0) s.User = UserService.GetUser((int)s.UserID);
            return s;
        }

        public static List<Sample> GetAll()
        {
            ef.Configuration.LazyLoadingEnabled = false;
            return ef.Sample.Include("User").ToList();
        }

        public static void Create(Sample s)
        {
            ef.Sample.Add(s);
            ef.SaveChanges();
        }

        public static void Update(Sample s)
        {
            var temp = ef.Sample.Where(x => x.Id == s.Id).FirstOrDefault();
            SampleMapper.CloneSample(ref temp, s);
            ef.SaveChanges();
        }

        public static void Delete(Sample s)
        {
            var temp = ef.Sample.Where(x => x.Id == s.Id).FirstOrDefault();
            ef.Sample.Remove(temp);
            ef.SaveChanges();
        }
    }
}