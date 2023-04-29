using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using hostel.Data;
using hostel.Models;

namespace hostel.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class vacatesController : ApiController
    {
        private hostelContext db = new hostelContext();

        // GET: api/vacates
        public IQueryable<vacate> Getvacates()
        {
            return db.vacates;
        }

        // GET: api/vacates/5
        [ResponseType(typeof(vacate))]
        public IHttpActionResult Getvacate(long id)
        {
            vacate vacate = db.vacates.Find(id);
            if (vacate == null)
            {
                return NotFound();
            }

            return Ok(vacate);
        }

        // PUT: api/vacates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putvacate(long id, vacate vacate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vacate.id)
            {
                return BadRequest();
            }

            db.Entry(vacate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vacateExists(id))
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

        // POST: api/vacates
        [ResponseType(typeof(vacate))]
        public IHttpActionResult Postvacate(vacate vacate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vacates.Add(vacate);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vacate.id }, vacate);
        }

        // DELETE: api/vacates/5
        [ResponseType(typeof(vacate))]
        public IHttpActionResult Deletevacate(long id)
        {
            vacate vacate = db.vacates.Find(id);
            if (vacate == null)
            {
                return NotFound();
            }

            db.vacates.Remove(vacate);
            db.SaveChanges();

            return Ok(vacate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vacateExists(long id)
        {
            return db.vacates.Count(e => e.id == id) > 0;
        }
    }
}