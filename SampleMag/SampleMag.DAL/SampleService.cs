using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.DAL
{
    public class SampleService
    {
        protected static readonly SampleMagEntities ef = new SampleMagEntities(); 

        public static Sample GetSample(int id)
        {
            return ef.Sample.Where(x => x.Id == 1).FirstOrDefault();
        }

        public static List<Sample> GetAll()
        {
            return ef.Sample.ToList();
        }

        public static void Create(Sample s)
        {

        }
    }
}
