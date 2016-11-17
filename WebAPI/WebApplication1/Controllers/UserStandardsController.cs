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
    public class UserStandardsController : ApiController
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: api/UserStandards
        public IQueryable<UserStandard> GetUserStandards()
        {
            var users = db.UserStandards.Include(c => c.FavoritePromoters);
            users.Include(c => c.ParticipatedEvents);
            users.Include(c => c.Success);
            return users;
        }

        // GET: api/UserStandards/5
        [ResponseType(typeof(UserStandard))]
        public async Task<IHttpActionResult> GetUserStandard(string id)
        {
            UserStandard userStandard = await db.UserStandards.FindAsync(id);
            if (userStandard == null)
            {
                return NotFound();
            }

            return Ok(userStandard);
        }

        // PUT: api/UserStandards/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserStandard(string id, UserStandard userStandard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userStandard.Login)
            {
                return BadRequest();
            }

            db.Entry(userStandard).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserStandardExists(id))
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

        // POST: api/UserStandards
        [ResponseType(typeof(UserStandard))]
        public async Task<IHttpActionResult> PostUserStandard(UserStandard userStandard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserStandards.Add(userStandard);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserStandardExists(userStandard.Login))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userStandard.Login }, userStandard);
        }

        // DELETE: api/UserStandards/5
        [ResponseType(typeof(UserStandard))]
        public async Task<IHttpActionResult> DeleteUserStandard(string id)
        {
            UserStandard userStandard = await db.UserStandards.FindAsync(id);
            if (userStandard == null)
            {
                return NotFound();
            }

            db.UserStandards.Remove(userStandard);
            await db.SaveChangesAsync();

            return Ok(userStandard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserStandardExists(string id)
        {
            return db.UserStandards.Count(e => e.Login == id) > 0;
        }
    }
}