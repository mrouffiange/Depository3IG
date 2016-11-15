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
    public class SuccessesController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: api/Successes
        public IQueryable<Success> GetSuccesses()
        {
            return db.Successes;
        }

        // GET: api/Successes/5
        [ResponseType(typeof(Success))]
        public async Task<IHttpActionResult> GetSuccess(string id)
        {
            Success success = await db.Successes.FindAsync(id);
            if (success == null)
            {
                return NotFound();
            }

            return Ok(success);
        }

        // PUT: api/Successes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSuccess(string id, Success success)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != success.Name)
            {
                return BadRequest();
            }

            db.Entry(success).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuccessExists(id))
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

        // POST: api/Successes
        [ResponseType(typeof(Success))]
        public async Task<IHttpActionResult> PostSuccess(Success success)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Successes.Add(success);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SuccessExists(success.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = success.Name }, success);
        }

        // DELETE: api/Successes/5
        [ResponseType(typeof(Success))]
        public async Task<IHttpActionResult> DeleteSuccess(string id)
        {
            Success success = await db.Successes.FindAsync(id);
            if (success == null)
            {
                return NotFound();
            }

            db.Successes.Remove(success);
            await db.SaveChangesAsync();

            return Ok(success);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuccessExists(string id)
        {
            return db.Successes.Count(e => e.Name == id) > 0;
        }
    }
}