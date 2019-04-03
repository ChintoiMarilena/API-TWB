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
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class DepartsController : ApiController
    {
        private BazadeDateEntities db = new BazadeDateEntities();

        // GET: api/Departs
        public IQueryable<Depart> GetDepart()
        {
            return db.Depart;
        }

        // GET: api/Departs/5
        [ResponseType(typeof(Depart))]
        public IHttpActionResult GetDepart(int id)
        {
            Depart depart = db.Depart.Find(id);
            if (depart == null)
            {
                return NotFound();
            }

            return Ok(depart);
        }

        // PUT: api/Departs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepart(int id, Depart depart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != depart.Iddep)
            {
                return BadRequest();
            }

            db.Entry(depart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartExists(id))
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

        // POST: api/Departs
        [ResponseType(typeof(Depart))]
        public IHttpActionResult PostDepart(Depart depart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Depart.Add(depart);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = depart.Iddep }, depart);
        }

        // DELETE: api/Departs/5
        [ResponseType(typeof(Depart))]
        public IHttpActionResult DeleteDepart(int id)
        {
            Depart depart = db.Depart.Find(id);
            if (depart == null)
            {
                return NotFound();
            }

            db.Depart.Remove(depart);
            db.SaveChanges();

            return Ok(depart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartExists(int id)
        {
            return db.Depart.Count(e => e.Iddep == id) > 0;
        }
    }
}