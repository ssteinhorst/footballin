using DataSync;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Footballin.Controllers
{
    public class game_scheduleController : ApiController
    {
        private ffstatsEntities db = new ffstatsEntities();

        // GET: api/game_schedule
        public IQueryable<game_schedule> Getgame_schedule()
        {
            return db.game_schedule;
        }

        // GET: api/game_schedule/5
        [ResponseType(typeof(game_schedule))]
        public IHttpActionResult Getgame_schedule(int id)
        {
            game_schedule game_schedule = db.game_schedule.Find(id);
            if (game_schedule == null)
            {
                return NotFound();
            }

            return Ok(game_schedule);
        }

        // PUT: api/game_schedule/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgame_schedule(int id, game_schedule game_schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game_schedule.eid)
            {
                return BadRequest();
            }

            db.Entry(game_schedule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!game_scheduleExists(id))
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

        // POST: api/game_schedule
        [ResponseType(typeof(game_schedule))]
        public IHttpActionResult Postgame_schedule(game_schedule game_schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.game_schedule.Add(game_schedule);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (game_scheduleExists(game_schedule.eid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = game_schedule.eid }, game_schedule);
        }

        // DELETE: api/game_schedule/5
        [ResponseType(typeof(game_schedule))]
        public IHttpActionResult Deletegame_schedule(int id)
        {
            game_schedule game_schedule = db.game_schedule.Find(id);
            if (game_schedule == null)
            {
                return NotFound();
            }

            db.game_schedule.Remove(game_schedule);
            db.SaveChanges();

            return Ok(game_schedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool game_scheduleExists(int id)
        {
            return db.game_schedule.Count(e => e.eid == id) > 0;
        }
    }
}