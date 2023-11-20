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
    public class FutbolcularsController : ApiController
    {
        private FutbolApiMvcEntities db = new FutbolApiMvcEntities();

        // GET: api/Futbolculars
        public IQueryable<Futbolcular> GetFutbolculars()
        {
            return db.Futbolculars;
        }

        // GET: api/Futbolculars/5
        [ResponseType(typeof(Futbolcular))]
        public async Task<IHttpActionResult> GetFutbolcular(int id)
        {
            Futbolcular futbolcular = await db.Futbolculars.FindAsync(id);
            if (futbolcular == null)
            {
                return NotFound();
            }

            return Ok(futbolcular);
        }

        // PUT: api/Futbolculars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFutbolcular(int id, Futbolcular futbolcular)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != futbolcular.FormaNo)
            {
                return BadRequest();
            }

            db.Entry(futbolcular).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FutbolcularExists(id))
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

        // POST: api/Futbolculars
        [ResponseType(typeof(Futbolcular))]
        public async Task<IHttpActionResult> PostFutbolcular(Futbolcular futbolcular)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Futbolculars.Add(futbolcular);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = futbolcular.FormaNo }, futbolcular);
        }

        // DELETE: api/Futbolculars/5
        [ResponseType(typeof(Futbolcular))]
        public async Task<IHttpActionResult> DeleteFutbolcular(int id)
        {
            Futbolcular futbolcular = await db.Futbolculars.FindAsync(id);
            if (futbolcular == null)
            {
                return NotFound();
            }

            db.Futbolculars.Remove(futbolcular);
            await db.SaveChangesAsync();

            return Ok(futbolcular);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FutbolcularExists(int id)
        {
            return db.Futbolculars.Count(e => e.FormaNo == id) > 0;
        }
    }
}