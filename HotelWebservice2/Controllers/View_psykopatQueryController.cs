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
using HotelWebservice2;

namespace HotelWebservice2.Controllers
{
    public class View_psykopatQueryController : ApiController
    {
        private ViewPsykopatContext2 db = new ViewPsykopatContext2();

        // GET: api/View_psykopatQuery
        public IQueryable<View_psykopatQuery> GetView_psykopatQuery()
        {
            return db.View_psykopatQuery;
        }

        // GET: api/View_psykopatQuery/5
        [ResponseType(typeof(View_psykopatQuery))]
        public async Task<IHttpActionResult> GetView_psykopatQuery(int id)
        {
            View_psykopatQuery view_psykopatQuery = await db.View_psykopatQuery.FindAsync(id);
            if (view_psykopatQuery == null)
            {
                return NotFound();
            }

            return Ok(view_psykopatQuery);
        }

        // PUT: api/View_psykopatQuery/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutView_psykopatQuery(int id, View_psykopatQuery view_psykopatQuery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != view_psykopatQuery.Room_No)
            {
                return BadRequest();
            }

            db.Entry(view_psykopatQuery).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!View_psykopatQueryExists(id))
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

        // POST: api/View_psykopatQuery
        [ResponseType(typeof(View_psykopatQuery))]
        public async Task<IHttpActionResult> PostView_psykopatQuery(View_psykopatQuery view_psykopatQuery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.View_psykopatQuery.Add(view_psykopatQuery);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (View_psykopatQueryExists(view_psykopatQuery.Room_No))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = view_psykopatQuery.Room_No }, view_psykopatQuery);
        }

        // DELETE: api/View_psykopatQuery/5
        [ResponseType(typeof(View_psykopatQuery))]
        public async Task<IHttpActionResult> DeleteView_psykopatQuery(int id)
        {
            View_psykopatQuery view_psykopatQuery = await db.View_psykopatQuery.FindAsync(id);
            if (view_psykopatQuery == null)
            {
                return NotFound();
            }

            db.View_psykopatQuery.Remove(view_psykopatQuery);
            await db.SaveChangesAsync();

            return Ok(view_psykopatQuery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool View_psykopatQueryExists(int id)
        {
            return db.View_psykopatQuery.Count(e => e.Room_No == id) > 0;
        }
    }
}