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
using Labo3;

namespace WebApplication1.Controllers
{
    public class ParticipationsController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: api/Participations
        public IQueryable<Participation> GetParticipations()
        {
            return db.Participations;
        }

        // GET: api/Participations/5
        [ResponseType(typeof(Participation))]
        public async Task<IHttpActionResult> GetParticipation(string id)
        {
            Participation participation = await db.Participations.FindAsync(id);
            if (participation == null)
            {
                return NotFound();
            }

            return Ok(participation);
        }

        // PUT: api/Participations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutParticipation(string id, Participation participation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participation.UserLogin)
            {
                return BadRequest();
            }

            db.Entry(participation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipationExists(id))
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

        // POST: api/Participations
        [ResponseType(typeof(Participation))]
        public async Task<IHttpActionResult> PostParticipation(Participation participation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Participations.Add(participation);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParticipationExists(participation.UserLogin))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = participation.UserLogin }, participation);
        }

        // DELETE: api/Participations/5
        [ResponseType(typeof(Participation))]
        public async Task<IHttpActionResult> DeleteParticipation(string id)
        {
            Participation participation = await db.Participations.FindAsync(id);
            if (participation == null)
            {
                return NotFound();
            }

            db.Participations.Remove(participation);
            await db.SaveChangesAsync();

            return Ok(participation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipationExists(string id)
        {
            return db.Participations.Count(e => e.UserLogin == id) > 0;
        }
    }
}