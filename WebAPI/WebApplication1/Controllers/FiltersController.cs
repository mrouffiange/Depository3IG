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
    public class FiltersController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: api/Filters
        public IQueryable<Filter> GetFilters()
        {
            return db.Filters;
        }

        // GET: api/Filters/5
        [ResponseType(typeof(Filter))]
        public async Task<IHttpActionResult> GetFilter(string id)
        {
            Filter filter = await db.Filters.FindAsync(id);
            if (filter == null)
            {
                return NotFound();
            }

            return Ok(filter);
        }

        // PUT: api/Filters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFilter(string id, Filter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != filter.Tag)
            {
                return BadRequest();
            }

            db.Entry(filter).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilterExists(id))
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

        // POST: api/Filters
        [ResponseType(typeof(Filter))]
        public async Task<IHttpActionResult> PostFilter(Filter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Filters.Add(filter);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FilterExists(filter.Tag))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = filter.Tag }, filter);
        }

        // DELETE: api/Filters/5
        [ResponseType(typeof(Filter))]
        public async Task<IHttpActionResult> DeleteFilter(string id)
        {
            Filter filter = await db.Filters.FindAsync(id);
            if (filter == null)
            {
                return NotFound();
            }

            db.Filters.Remove(filter);
            await db.SaveChangesAsync();

            return Ok(filter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilterExists(string id)
        {
            return db.Filters.Count(e => e.Tag == id) > 0;
        }
    }
}