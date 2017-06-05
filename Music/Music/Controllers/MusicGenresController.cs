using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Music.EF;

namespace Music.Controllers
{
    public class MusicGenresController : ApiController
    {
        private SampleMagDatabaseEntities db = new SampleMagDatabaseEntities();

        // GET: api/MusicGenres
        public IQueryable<MusicGenre> GetMusicGenre()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return db.MusicGenre;
        }

        // GET: api/MusicGenres/5
        [ResponseType(typeof(MusicGenre))]
        public async Task<IHttpActionResult> GetMusicGenre(int id)
        {
            MusicGenre musicGenre = await db.MusicGenre.FindAsync(id);
            if (musicGenre == null)
            {
                return NotFound();
            }

            return Ok(musicGenre);
        }

        // PUT: api/MusicGenres/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMusicGenre(int id, MusicGenre musicGenre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != musicGenre.Id)
            {
                return BadRequest();
            }

            db.Entry(musicGenre).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicGenreExists(id))
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

        // POST: api/MusicGenres
        [ResponseType(typeof(MusicGenre))]
        public async Task<IHttpActionResult> PostMusicGenre(MusicGenre musicGenre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MusicGenre.Add(musicGenre);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MusicGenreExists(musicGenre.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = musicGenre.Id }, musicGenre);
        }

        // DELETE: api/MusicGenres/5
        [ResponseType(typeof(MusicGenre))]
        public async Task<IHttpActionResult> DeleteMusicGenre(int id)
        {
            MusicGenre musicGenre = await db.MusicGenre.FindAsync(id);
            if (musicGenre == null)
            {
                return NotFound();
            }

            db.MusicGenre.Remove(musicGenre);
            await db.SaveChangesAsync();

            return Ok(musicGenre);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MusicGenreExists(int id)
        {
            return db.MusicGenre.Count(e => e.Id == id) > 0;
        }
    }
}