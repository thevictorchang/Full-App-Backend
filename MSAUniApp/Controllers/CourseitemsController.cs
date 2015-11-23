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
using MSAUniApp.Models;

namespace MSAUniApp.Controllers
{
    public class CourseitemsController : ApiController
    {
        private MSAUniAppContext db = new MSAUniAppContext();

        // GET: api/Courseitems
        public IQueryable<Courseitem> GetCourseitems()
        {
            return db.Courseitems;
        }

        // GET: api/Courseitems/5
        [ResponseType(typeof(Courseitem))]
        public IHttpActionResult GetCourseitem(int id)
        {
            Courseitem courseitem = db.Courseitems.Find(id);
            if (courseitem == null)
            {
                return NotFound();
            }

            return Ok(courseitem);
        }

        // PUT: api/Courseitems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourseitem(int id, Courseitem courseitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courseitem.ID)
            {
                return BadRequest();
            }

            db.Entry(courseitem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseitemExists(id))
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

        // POST: api/Courseitems
        [ResponseType(typeof(Courseitem))]
        public IHttpActionResult PostCourseitem(Courseitem courseitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courseitems.Add(courseitem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CourseitemExists(courseitem.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = courseitem.ID }, courseitem);
        }

        // DELETE: api/Courseitems/5
        [ResponseType(typeof(Courseitem))]
        public IHttpActionResult DeleteCourseitem(int id)
        {
            Courseitem courseitem = db.Courseitems.Find(id);
            if (courseitem == null)
            {
                return NotFound();
            }

            db.Courseitems.Remove(courseitem);
            db.SaveChanges();

            return Ok(courseitem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseitemExists(int id)
        {
            return db.Courseitems.Count(e => e.ID == id) > 0;
        }
    }
}