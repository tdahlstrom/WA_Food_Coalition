using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Services {
    public interface ILocationService {
        List<FoodBankDistanceResult> GetNearbyFoodBanks(double latitude, double longitude, int amountToReturn);
        List<DonationDistanceResult> GetNearbyDonations(double latitude, double longitude);
    }
}