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
    public class outPassesController : ApiController
    {
        private hostelContext db = new hostelContext();

        // GET: api/outPasses
        public IQueryable<outPass> GetoutPasses()
        {
            return db.outPasses;
        }

        // GET: api/outPasses/5
        [ResponseType(typeof(outPass))]
        public IHttpActionResult GetoutPass(long id)
        {
            outPass outPass = db.outPasses.Find(id);
            if (outPass == null)
            {
                return NotFound();
            }

            return Ok(outPass);
        }

        // PUT: api/outPasses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutoutPass(long id, outPass outPass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != outPass.id)
            {
                return BadRequest();
            }

            db.Entry(outPass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!outPassExists(id))
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

        // POST: api/outPasses
        [ResponseType(typeof(outPass))]
        public IHttpActionResult PostoutPass(outPass outPass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.outPasses.Add(outPass);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = outPass.id }, outPass);
        }

        // DELETE: api/outPasses/5
        [ResponseType(typeof(outPass))]
        public IHttpActionResult DeleteoutPass(long id)
        {
            outPass outPass = db.outPasses.Find(id);
            if (outPass == null)
            {
                return NotFound();
            }

            db.outPasses.Remove(outPass);
            db.SaveChanges();

            return Ok(outPass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool outPassExists(long id)
        {
            return db.outPasses.Count(e => e.id == id) > 0;
        }
    }
}