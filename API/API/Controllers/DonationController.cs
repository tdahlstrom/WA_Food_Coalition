﻿using System;
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

namespace API.Controllers
{
    public class DonationController : ApiController
    {
        private FoodCoalitionAppContext db = new FoodCoalitionAppContext();

        // GET api/Donation
        public IQueryable<Donation> GetDonations()
        {
            Donation d = new Donation();
            //d.Name = "Abe";
            //d.Email = "some@hotmail.com";
            //d.Description = "5 pounds of potatoes";
            //d.ExpirationDate = DateTime.Now;
            //d.Latitude = 16.0;
            //d.Longitude = 65.0;
            //d.Phone = "5555555555";
            //d.Status = "New";
            //d.Address = "some random place";

        
            //db.Donations.Add(d);
            //db.SaveChanges();
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

        // Get donations associated to the ** FoodBank ID **
        public IQueryable<Donation> Get(int foodBankId) {
            return db.Donations.Where(d => d.FoodBankID == foodBankId).AsQueryable();
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