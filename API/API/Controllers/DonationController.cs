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
using API.Models;
using API.Services;

namespace API.Controllers
{
    public class DonationController : ApiController
    {
        private FoodCoalitionAppContext db = new FoodCoalitionAppContext();
        private ILocationService locationService = new ConcreteLocationService();

        // GET api/Donation
        public IQueryable<Donation> GetDonations()
        {
            Donation d = new Donation();
            return db.Donations;
        }

        // GET api/Donation/5
        [ResponseType(typeof(Donation))]
        public IHttpActionResult GetDonation(int id)
        {
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return NotFound();
            }

            return Ok(donation);
        }

        // Get donations associated to the ** FoodBank ID ** that are pending
        public IQueryable<Donation> Get(int foodBankId, string status) {
            return db.Donations.Where(d => d.FoodBankID == foodBankId && d.Status.Equals(status)).AsQueryable();
        }

        // Get donations that are near the food bank
        public IQueryable<Donation> Get(int foodBankId) {
            FoodBank foodBank = db.FoodBanks.Find(foodBankId);
            if (foodBank == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return locationService.GetNearbyDonations(foodBank.Latitude, foodBank.Longitude).AsQueryable();
        }

        // PUT api/Donation/5
        public IHttpActionResult PutDonation(int id, Donation donation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donation.ID)
            {
                return BadRequest();
            }

            db.Entry(donation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        [ActionName("Status")]
        // PUT api/Donation/Status/7?status=open&foodbankid=1
        public IHttpActionResult PutStatus(int id, [FromUri]string status, [FromUri]int foodbankid)
        {
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return NotFound();
            }
            donation.Status = status;
            donation.FoodBankID = foodbankid;

            db.Entry(donation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST api/Donation
        [ResponseType(typeof(Donation))]
        public IHttpActionResult PostDonation(Donation donation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Donations.Add(donation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donation.ID }, donation);
        }

        // DELETE api/Donation/5
        [ResponseType(typeof(Donation))]
        public IHttpActionResult DeleteDonation(int id)
        {
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return NotFound();
            }

            db.Donations.Remove(donation);
            db.SaveChanges();

            return Ok(donation);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private bool DonationExists(int id)
        {
            return db.Donations.Count(e => e.ID == id) > 0;
        }
    }
}