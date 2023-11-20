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
    public class HakemlersController : ApiController
    {
        private FutbolApiMvcEntities db = new FutbolApiMvcEntities();

        // GET: api/Hakemlers
        public IQueryable<Hakemler> GetHakemlers()
        {
            return db.Hakemlers;
        }

        // GET: api/Hakemlers/5
        [ResponseType(typeof(Hakemler))]
        public async Task<IHttpActionResult> GetHakemler(int id)
        {
            Hakemler hakemler = await db.Hakemlers.FindAsync(id);
            if (hakemler == null)
            {
                return NotFound();
            }

            return Ok(hakemler);
        }

        // PUT: api/Hakemlers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHakemler(int id, Hakemler hakemler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hakemler.HakemId)
            {
                return BadRequest();
            }

            db.Entry(hakemler).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HakemlerExists(id))
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

        // POST: api/Hakemlers
        [ResponseType(typeof(Hakemler))]
        public async Task<IHttpActionResult> PostHakemler(Hakemler hakemler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hakemlers.Add(hakemler);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hakemler.HakemId }, hakemler);
        }

        // DELETE: api/Hakemlers/5
        [ResponseType(typeof(Hakemler))]
        public async Task<IHttpActionResult> DeleteHakemler(int id)
        {
            Hakemler hakemler = await db.Hakemlers.FindAsync(id);
            if (hakemler == null)
            {
                return NotFound();
            }

            db.Hakemlers.Remove(hakemler);
            await db.SaveChangesAsync();

            return Ok(hakemler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HakemlerExists(int id)
        {
            return db.Hakemlers.Count(e => e.HakemId == id) > 0;
        }
    }
}