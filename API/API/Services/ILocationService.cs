using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Services {
    public interface ILocationService {
        public List<FoodBank> GetNearbyFoodBanks(double latitude, double longitude, int amountToReturn);
        public List<Donation> GetNearbyDonations(FoodBank foodBank);
    }
}