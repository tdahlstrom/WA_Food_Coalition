using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Services {
    public interface ILocationService {
        List<FoodBank> GetNearbyFoodBanks(double latitude, double longitude, int amountToReturn);
        List<Donation> GetNearbyDonations(double latitude, double longitude);
    }
}