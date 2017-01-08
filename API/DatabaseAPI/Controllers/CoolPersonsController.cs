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
using DatabaseAPI.Models;

namespace DatabaseAPI.Controllers
{
    public class CoolPersonsController : ApiController
    {
        private FromDatabaseToBrowserEntities db = new FromDatabaseToBrowserEntities();

        // GET: api/CoolPersons
        public IQueryable<CoolPerson> GetCoolPersons()
        {
            return db.CoolPersons;
        }

        // GET: api/CoolPersons/5
        [ResponseType(typeof(CoolPerson))]
        public async Task<IHttpActionResult> GetCoolPerson(int id)
        {
            CoolPerson coolPerson = await db.CoolPersons.FindAsync(id);
            if (coolPerson == null)
            {
                return NotFound();
            }

            return Ok(coolPerson);
        }

        // PUT: api/CoolPersons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCoolPerson(int id, CoolPerson coolPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coolPerson.Id)
            {
                return BadRequest();
            }

            db.Entry(coolPerson).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoolPersonExists(id))
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

        // POST: api/CoolPersons
        [ResponseType(typeof(CoolPerson))]
        public async Task<IHttpActionResult> PostCoolPerson(CoolPerson coolPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CoolPersons.Add(coolPerson);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = coolPerson.Id }, coolPerson);
        }

        // DELETE: api/CoolPersons/5
        [ResponseType(typeof(CoolPerson))]
        public async Task<IHttpActionResult> DeleteCoolPerson(int id)
        {
            CoolPerson coolPerson = await db.CoolPersons.FindAsync(id);
            if (coolPerson == null)
            {
                return NotFound();
            }

            db.CoolPersons.Remove(coolPerson);
            await db.SaveChangesAsync();

            return Ok(coolPerson);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoolPersonExists(int id)
        {
            return db.CoolPersons.Count(e => e.Id == id) > 0;
        }
    }
}