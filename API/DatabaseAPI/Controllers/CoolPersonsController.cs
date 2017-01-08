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

        [HttpGet, Route("CoolPersons/AverageCoolness")]
        public decimal? GetAverageCoolness()
        {
            return db.CoolPersons.Average(cP => cP.Coolness);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}