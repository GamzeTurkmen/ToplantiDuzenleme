using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Meeting.Models;

namespace Meeting.Controllers
{
    public class KatilimcisController : ApiController
    {
        private ToplantiContext db = new ToplantiContext();

        // GET: api/Katilimcis
        public IQueryable<Katilimci> GetKatilimcilar()
        {
            return db.Katilimcilar;
        }

        // GET: api/Katilimcis/5
        [ResponseType(typeof(Katilimci))]
        public IHttpActionResult GetKatilimci(int id)
        {
            Katilimci katilimci = db.Katilimcilar.Find(id);
            if (katilimci == null)
            {
                return NotFound();
            }

            return Ok(katilimci);
        }

        // PUT: api/Katilimcis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKatilimci(int id, Katilimci katilimci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != katilimci.ID)
            {
                return BadRequest();
            }

            db.Entry(katilimci).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KatilimciExists(id))
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

        // POST: api/Katilimcis
        [ResponseType(typeof(Katilimci))]
        public IHttpActionResult PostKatilimci(Katilimci katilimci)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Katilimcilar.Add(katilimci);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = katilimci.ID }, katilimci);
        }

        // DELETE: api/Katilimcis/5
        [ResponseType(typeof(Katilimci))]
        public IHttpActionResult DeleteKatilimci(int id)
        {
            Katilimci katilimci = db.Katilimcilar.Find(id);
            if (katilimci == null)
            {
                return NotFound();
            }

            db.Katilimcilar.Remove(katilimci);
            db.SaveChanges();

            return Ok(katilimci);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KatilimciExists(int id)
        {
            return db.Katilimcilar.Count(e => e.ID == id) > 0;
        }
    }
}