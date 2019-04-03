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
    public class AngajatsController : ApiController
    {
        private BazadeDateEntities db = new BazadeDateEntities();

        // GET: api/Angajats
        public IQueryable<Angajat> GetAngajat()
        {
            return db.Angajat;
        }

        // GET: api/Angajats/5
        [ResponseType(typeof(Angajat))]
        public IHttpActionResult GetAngajat(int id)
        {
            Angajat angajat = db.Angajat.Find(id);
            if (angajat == null)
            {
                return NotFound();
            }

            return Ok(angajat);
        }
        [HttpGet]
        public List<Angajat> GetAngajatByDepartmentId(int id)
        {
            var lista = db.Angajat.Where(x => x.Iddep == id).ToList();
            return lista;
        }

        // PUT: api/Angajats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAngajat(int id, Angajat angajat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != angajat.marca)
            {
                return BadRequest();
            }

            db.Entry(angajat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AngajatExists(id))
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

        // POST: api/Angajats
        [ResponseType(typeof(Angajat))]
        public IHttpActionResult PostAngajat(Angajat angajat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Angajat.Add(angajat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = angajat.marca }, angajat);
        }

        // DELETE: api/Angajats/5
        [ResponseType(typeof(Angajat))]
        public IHttpActionResult DeleteAngajat(int id)
        {
            Angajat angajat = db.Angajat.Find(id);
            if (angajat == null)
            {
                return NotFound();
            }

            db.Angajat.Remove(angajat);
            db.SaveChanges();

            return Ok(angajat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AngajatExists(int id)
        {
            return db.Angajat.Count(e => e.marca == id) > 0;
        }
    }
}