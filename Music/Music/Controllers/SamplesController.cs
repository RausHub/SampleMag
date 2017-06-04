
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Music.EF;
using Music.Models.Service;
using Newtonsoft.Json;

namespace Music.Controllers
{
    public class SamplesController : ApiController
    {
        private SampleMagDatabaseEntities db = new SampleMagDatabaseEntities();

        // GET: api/Samples
        public IQueryable<Sample> GetSample()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return db.Sample;
        }

        //GET: api/samples/genre/:genreid
        [HttpGet]
        [Route("api/samples/genre/{genreID}")]
        public IQueryable<Sample> Genre(int genreId)
        {
            db.Configuration.LazyLoadingEnabled = false;
            var y = db.Sample.Where(x=>x.MusicGenreID == genreId);
            var z = y.ToList();
            return y;
        }
        // GET: api/Samples/5
        [ResponseType(typeof(Sample))]
        public async Task<IHttpActionResult> GetSample(int id)
        {
            Sample sample = await db.Sample.FindAsync(id);
            if (sample == null)
            {
                return NotFound();
            }

            return Ok(sample);
        }

        // PUT: api/Samples/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSample(int id, Sample sample)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sample.Id)
            {
                return BadRequest();
            }

            db.Entry(sample).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Samples
        [ResponseType(typeof(Sample))]
        public async Task<IHttpActionResult> PostSample(Sample sample)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sample.Add(sample);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SampleExists(sample.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sample.Id }, sample);
        }

        // DELETE: api/Samples/5
        [ResponseType(typeof(Sample))]
        public async Task<IHttpActionResult> DeleteSample(int id)
        {
            Sample sample = await db.Sample.FindAsync(id);
            if (sample == null)
            {
                return NotFound();
            }

            db.Sample.Remove(sample);
            await db.SaveChangesAsync();

            return Ok(sample);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SampleExists(int id)
        {
            return db.Sample.Count(e => e.Id == id) > 0;
        }
    }
}