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
using futbolApiMvc.Models;

namespace futbolApiMvc.Controllers
{
    public class TakimlarsController : ApiController
    {
        private FutbolApiMvcEntities db = new FutbolApiMvcEntities();

        // GET: api/Takimlars
        public IQueryable<Takimlar> GetTakimlars()
        {
            return db.Takimlars;
        }

        // GET: api/Takimlars/5
        [ResponseType(typeof(Takimlar))]
        public async Task<IHttpActionResult> GetTakimlar(int id)
        {
            Takimlar takimlar = await db.Takimlars.FindAsync(id);
            if (takimlar == null)
            {
                return NotFound();
            }

            return Ok(takimlar);
        }

        // PUT: api/Takimlars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTakimlar(int id, Takimlar takimlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != takimlar.TakimId)
            {
                return BadRequest();
            }

            db.Entry(takimlar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TakimlarExists(id))
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

        // POST: api/Takimlars
        [ResponseType(typeof(Takimlar))]
        public async Task<IHttpActionResult> PostTakimlar(Takimlar takimlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Takimlars.Add(takimlar);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = takimlar.TakimId }, takimlar);
        }

        // DELETE: api/Takimlars/5
        [ResponseType(typeof(Takimlar))]
        public async Task<IHttpActionResult> DeleteTakimlar(int id)
        {
            Takimlar takimlar = await db.Takimlars.FindAsync(id);
            if (takimlar == null)
            {
                return NotFound();
            }

            db.Takimlars.Remove(takimlar);
            await db.SaveChangesAsync();

            return Ok(takimlar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TakimlarExists(int id)
        {
            return db.Takimlars.Count(e => e.TakimId == id) > 0;
        }
    }
}