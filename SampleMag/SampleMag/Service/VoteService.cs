using SampleMag.Models.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMag.Service
{
    public class VoteService
    {
        protected static readonly SampleMagDatabaseEntities ef = new SampleMagDatabaseEntities();

        public static Vote GetVote(int id)
        {
            ef.Configuration.LazyLoadingEnabled = false;
            return ef.Vote.Where(x => x.Id == id).FirstOrDefault();
        }

        public static List<Vote> GetAll()
        {
            ef.Configuration.LazyLoadingEnabled = false;
            return ef.Vote.ToList();
        }

        public static void Create(Vote v)
        {
            ef.Vote.Add(v);
            ef.SaveChanges();
        }

        public static void Update(Vote v)
        {
            var temp = ef.Vote.Where(x => x.Id == v.Id).FirstOrDefault();
            VoteConverter.CloneVote(ref temp, v);
            ef.SaveChanges();
        }

        public static void Delete(Vote v)
        {
            var temp = ef.Vote.Where(x => x.Id == v.Id).FirstOrDefault();
            ef.Vote.Remove(temp);
            ef.SaveChanges();
        }
    }
}