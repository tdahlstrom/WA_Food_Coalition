using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Services {
    public class TestLocationService : ILocationService {

        public List<FoodBankDistanceResult> GetNearbyFoodBanks(double latitude, double longitude, int amountToReturn) {
            throw new NotImplementedException();
        }

        public List<DonationDistanceResult> GetNearbyDonations(double latitude, double longitude) {
            throw new NotImplementedException();
        }
    }
}