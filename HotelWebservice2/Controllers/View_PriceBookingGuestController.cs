using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HotelWebservice2;

namespace HotelWebservice2.Controllers
{
    public class View_PriceBookingGuestController : ApiController
    {
        private ViewHotelContext db = new ViewHotelContext();

        // GET: api/View_PriceBookingGuest
        public IQueryable<View_PriceBookingGuest> GetView_PriceBookingGuest()
        {
            return db.View_PriceBookingGuest;
        }

        // GET: api/View_PriceBookingGuest/5
        [ResponseType(typeof(View_PriceBookingGuest))]
        public IHttpActionResult GetView_PriceBookingGuest(int id)
        {
            View_PriceBookingGuest view_PriceBookingGuest = db.View_PriceBookingGuest.Find(id);
            if (view_PriceBookingGuest == null)
            {
                return NotFound();
            }

            return Ok(view_PriceBookingGuest);
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