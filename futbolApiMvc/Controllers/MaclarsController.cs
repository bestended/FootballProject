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
    public class MaclarsController : ApiController
    {
        private FutbolApiMvcEntities db = new FutbolApiMvcEntities();

        // GET: api/Maclars
        public IQueryable<Maclar> GetMaclars()
        {
            return db.Maclars;
        }

        // GET: api/Maclars/5
        [ResponseType(typeof(Maclar))]
        public async Task<IHttpActionResult> GetMaclar(int id)
        {
            Maclar maclar = await db.Maclars.FindAsync(id);
            if (maclar == null)
            {
                return NotFound();
            }

            return Ok(maclar);
        }

        // PUT: api/Maclars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMaclar(int id, Maclar maclar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maclar.MacId)
            {
                return BadRequest();
            }

            db.Entry(maclar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaclarExists(id))
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

        // POST: api/Maclars
        [ResponseType(typeof(Maclar))]
        public async Task<IHttpActionResult> PostMaclar(Maclar maclar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Maclars.Add(maclar);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = maclar.MacId }, maclar);
        }

        // DELETE: api/Maclars/5
        [ResponseType(typeof(Maclar))]
        public async Task<IHttpActionResult> DeleteMaclar(int id)
        {
            Maclar maclar = await db.Maclars.FindAsync(id);
            if (maclar == null)
            {
                return NotFound();
            }

            db.Maclars.Remove(maclar);
            await db.SaveChangesAsync();

            return Ok(maclar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaclarExists(int id)
        {
            return db.Maclars.Count(e => e.MacId == id) > 0;
        }
    }
}