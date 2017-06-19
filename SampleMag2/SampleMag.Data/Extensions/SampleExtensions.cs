using SampleMag.Data.Repositories;
using SampleMag.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMag.Data.Extensions
{
    public static class SampleExtensions
    {
        public static IEnumerable<Sample> GetAllByUser (this IEntityBaseRepository<Sample> sampleRepo, int userId)
        {
            var x = sampleRepo.GetAll().Where(s => s.UserId == userId);
            return x;
        }

        public static IEnumerable<Sample> GetAllByGenre (this IEntityBaseRepository<Sample> sampleRepo, int genreId)
        {
            return sampleRepo.GetAll().Where(s => s.GenreId == genreId);
        }
    } 
}
