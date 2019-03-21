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
    public class ToplantisController : ApiController
    {
        private ToplantiContext db = new ToplantiContext();

        // GET: api/Toplantis
        public IQueryable<Toplanti> GetToplantilar()
        {
            return db.Toplantilar;
        }

        // GET: api/Toplantis/5
        [ResponseType(typeof(Toplanti))]
        public IHttpActionResult GetToplanti(int id)
        {
            Toplanti toplanti = db.Toplantilar.Find(id);
            if (toplanti == null)
            {
                return NotFound();
            }

            return Ok(toplanti);
        }

        // PUT: api/Toplantis/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutToplanti(int id, Toplanti toplanti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toplanti.ID)
            {
                return BadRequest();
            }

            db.Entry(toplanti).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToplantiExists(id))
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

        // POST: api/Toplantis
        [ResponseType(typeof(Toplanti))]
        public IHttpActionResult PostToplanti(Toplanti toplanti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Toplantilar.Add(toplanti);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = toplanti.ID }, toplanti);
        }

        // DELETE: api/Toplantis/5
        [ResponseType(typeof(Toplanti))]
        public IHttpActionResult DeleteToplanti(int id)
        {
            Toplanti toplanti = db.Toplantilar.Find(id);
            if (toplanti == null)
            {
                return NotFound();
            }

            db.Toplantilar.Remove(toplanti);
            db.SaveChanges();

            return Ok(toplanti);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToplantiExists(int id)
        {
            return db.Toplantilar.Count(e => e.ID == id) > 0;
        }
    }
}