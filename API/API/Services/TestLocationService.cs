using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Services {
    public class TestLocationService : ILocationService {

        public List<FoodBank> GetNearbyFoodBanks(double latitude, double longitude, int amountToReturn) {
            throw new NotImplementedException();
        }

        public List<Donation> GetNearbyDonations(FoodBank foodBank) {
            throw new NotImplementedException();
        }
    }
}