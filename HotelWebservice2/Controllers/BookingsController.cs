using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HotelWebservice2;
using HotelWebservice2.DTO;

namespace HotelWebservice2.Controllers
{
    public class BookingsController : ApiController
    {
        private HotelContext db = new HotelContext();

        private static readonly Expression<Func<Booking, BookingDTO>> AsBookingDto =
         x => new BookingDTO()
         {
        Booking_id = x.Booking_id,
        Hotel_No =  x.Hotel_No
         };

        [Route("api/Bookings/{GuestNo:int}/Guest")]
        [HttpGet]
        public IEnumerable<Booking> GetBookingByGuestNo(int GuestNo)
        {

            return db.Booking.Where(x => x.Guest_No == GuestNo);
        } 




        // GET: api/Bookings
        public IQueryable<Booking> GetBooking()
        {
            return db.Booking;
        }

        // GET: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public IHttpActionResult GetBooking(int id)
        {
            Booking booking = db.Booking.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // PUT: api/Bookings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBooking(int id, Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking.Booking_id)
            {
                return BadRequest();
            }

            db.Entry(booking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
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

        // POST: api/Bookings
        [ResponseType(typeof(Booking))]
        public IHttpActionResult PostBooking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Booking.Add(booking);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = booking.Booking_id }, booking);
        }

        // DELETE: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public IHttpActionResult DeleteBooking(int id)
        {
            Booking booking = db.Booking.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            db.Booking.Remove(booking);
            db.SaveChanges();

            return Ok(booking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingExists(int id)
        {
            return db.Booking.Count(e => e.Booking_id == id) > 0;
        }
    }
}