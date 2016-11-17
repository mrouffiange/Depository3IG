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
    public class UserPromotersController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: api/UserPromoters
        public IQueryable<UserPromoter> GetUserPromoters()
        {
            var promoters = db.UserPromoters.Include(c => c.Type);
            promoters.Include(c => c.Events);
            promoters.Include(c => c.Followers);
            return promoters;
        }

        // GET: api/UserPromoters/5
        [ResponseType(typeof(UserPromoter))]
        public async Task<IHttpActionResult> GetUserPromoter(string id)
        {
            UserPromoter userPromoter = await db.UserPromoters.FindAsync(id);
            if (userPromoter == null)
            {
                return NotFound();
            }

            return Ok(userPromoter);
        }

        // PUT: api/UserPromoters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserPromoter(string id, UserPromoter userPromoter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userPromoter.Login)
            {
                return BadRequest();
            }

            db.Entry(userPromoter).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPromoterExists(id))
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

        // POST: api/UserPromoters
        [ResponseType(typeof(UserPromoter))]
        public async Task<IHttpActionResult> PostUserPromoter(UserPromoter userPromoter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserPromoters.Add(userPromoter);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserPromoterExists(userPromoter.Login))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userPromoter.Login }, userPromoter);
        }

        // DELETE: api/UserPromoters/5
        [ResponseType(typeof(UserPromoter))]
        public async Task<IHttpActionResult> DeleteUserPromoter(string id)
        {
            UserPromoter userPromoter = await db.UserPromoters.FindAsync(id);
            if (userPromoter == null)
            {
                return NotFound();
            }

            db.UserPromoters.Remove(userPromoter);
            await db.SaveChangesAsync();

            return Ok(userPromoter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserPromoterExists(string id)
        {
            return db.UserPromoters.Count(e => e.Login == id) > 0;
        }
    }
}