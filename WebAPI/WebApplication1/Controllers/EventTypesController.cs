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
    public class EventTypesController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: api/EventTypes
        public IQueryable<EventType> GetEventTypes()
        {
            return db.EventTypes;
        }

        // GET: api/EventTypes/5
        [ResponseType(typeof(EventType))]
        public async Task<IHttpActionResult> GetEventType(string id)
        {
            EventType eventType = await db.EventTypes.FindAsync(id);
            if (eventType == null)
            {
                return NotFound();
            }

            return Ok(eventType);
        }

        // PUT: api/EventTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventType(string id, EventType eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventType.Name)
            {
                return BadRequest();
            }

            db.Entry(eventType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTypeExists(id))
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

        // POST: api/EventTypes
        [ResponseType(typeof(EventType))]
        public async Task<IHttpActionResult> PostEventType(EventType eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventTypes.Add(eventType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EventTypeExists(eventType.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eventType.Name }, eventType);
        }

        // DELETE: api/EventTypes/5
        [ResponseType(typeof(EventType))]
        public async Task<IHttpActionResult> DeleteEventType(string id)
        {
            EventType eventType = await db.EventTypes.FindAsync(id);
            if (eventType == null)
            {
                return NotFound();
            }

            db.EventTypes.Remove(eventType);
            await db.SaveChangesAsync();

            return Ok(eventType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventTypeExists(string id)
        {
            return db.EventTypes.Count(e => e.Name == id) > 0;
        }
    }
}