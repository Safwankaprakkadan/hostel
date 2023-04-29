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
using Microsoft.AspNetCore.Http;
using hostel.Data;
using hostel.Models;
using Microsoft.AspNetCore.Mvc;

namespace hostel.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AddRoomsController : ApiController
    {
        private hostelContext db = new hostelContext();

        // GET: api/AddRooms
        public IQueryable<AddRoom> GetAddRooms()
        {
            return db.AddRooms;
        }

        // GET: api/AddRooms/5
        [ResponseType(typeof(AddRoom))]
        public IHttpActionResult GetAddRoom(long id)
        {
            AddRoom addRoom = db.AddRooms.Find(id);
            if (addRoom == null)
            {
                return NotFound();
            }

            return Ok(addRoom);
        }

        // PUT: api/AddRooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddRoom( long id, AddRoom addRoom )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != addRoom.id)
            {
                return BadRequest();
            }

            db.Entry(addRoom).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddRoomExists(id))
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

        // POST: api/AddRooms
        [ResponseType(typeof(AddRoom))]
        public IHttpActionResult PostAddRoom(AddRoom addRoom)
        {
            //IFormFile FilePath
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AddRooms.Add(addRoom);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = addRoom.id }, addRoom);

        }

        // DELETE: api/AddRooms/5
        [ResponseType(typeof(AddRoom))]
        public IHttpActionResult DeleteAddRoom(long id)
        {
            AddRoom addRoom = db.AddRooms.Find(id);
            if (addRoom == null)
            {
                return NotFound();
            }

            db.AddRooms.Remove(addRoom);
            db.SaveChanges();

            return Ok(addRoom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddRoomExists(long id)
        {
            return db.AddRooms.Count(e => e.id == id) > 0;
        }
    }
}