using API.Models;
using API.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers {
    public class FoodBankController : ApiController {
        private FoodCoalitionAppContext _db = new FoodCoalitionAppContext();
        private ILocationService _locationService = new ConcreteLocationService();
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

        // Update
        public IHttpActionResult Put(int id, FoodBank foodBank) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            if (id != foodBank.ID) {
                return BadRequest();
            }
            _db.Entry(foodBank).State = EntityState.Modified;

            try {
                _db.SaveChanges();
            } catch (DbUpdateConcurrencyException) {
                if (!FoodBankExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return Ok();
        }

        // Delete api/FoodBank/5
        [ResponseType(typeof (FoodBank))]
        public IHttpActionResult Delete(int id) {
            FoodBank foodBank = _db.FoodBanks.Find(id);

            if (foodBank == null) {
                return NotFound();
            }

            _db.FoodBanks.Remove(foodBank);
            _db.SaveChanges();

            return Ok();
        }

        private bool FoodBankExists(int id) {
            return _db.Donations.Count(e => e.ID == id) > 0;
        }
    }
}