using API.Models;
using API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers {
    public class FoodBankController : ApiController {
        private FoodCoalitionAppContext _db = new FoodCoalitionAppContext();
        private ILocationService _locationService = new TestLocationService();
        private int _defaultNearbyFoodBanks = Convert.ToInt32(WebConfigurationManager.AppSettings["DefaultAmountOfNearbyFoodBanksToReturn"]);

        public IQueryable<FoodBank> Get(double latitude, double longitude, int? amountToReturn) {
            if (amountToReturn == null)
                amountToReturn = _defaultNearbyFoodBanks;

            return _locationService.GetNearbyFoodBanks(latitude, longitude, (int)amountToReturn).AsQueryable();
        }

        // Get all foodbanks - detailed.
        public IQueryable<FoodBank> Get() {
            return _db.FoodBanks.OrderBy(fb => fb.Name);
        }

        // Insert
        [ResponseType(typeof (FoodBank))]
        public IHttpActionResult Post(FoodBank foodBank, string token) {
            if (WebConfigurationManager.AppSettings["AdminToken"] != token) {
                return BadRequest("Unauthorized.");
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _db.FoodBanks.Add(foodBank);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = foodBank.ID }, foodBank);
        }

    }
}

        //// POST api/Donation
        //[ResponseType(typeof(Donation))]
        //public IHttpActionResult PostDonation(Donation donation)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Donations.Add(donation);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = donation.ID }, donation);
        //}