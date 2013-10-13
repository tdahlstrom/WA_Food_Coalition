using API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Services
{
    public class ConcreteLocationService : ILocationService
    {

        public List<FoodBankDistanceResult> GetNearbyFoodBanks(double latitude, double longitude, int amountToReturn)
        {
            String _connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DonationContext"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.usp_GetNearDonations", connection))
                {
                    List<FoodBankDistanceResult> result = new List<FoodBankDistanceResult>();
                    command.CommandType = CommandType.StoredProcedure;
                    #region Add Parameters
                    command.Parameters.Add(new SqlParameter("@latitude", latitude));
                    command.Parameters.Add(new SqlParameter("@longitude", longitude));
                    #endregion

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        FoodBankDistanceResult foodbank = new FoodBankDistanceResult();
                        foodbank.Name = reader.GetValue(0).ToString();
                        foodbank.Email = reader.GetValue(1).ToString();

                        // Need some extra logic for when distance == 0, since double.parse returns empty string
                        String distance = reader.GetValue(2).ToString();
                        if (distance.Equals(""))
                            foodbank.Distance = 0.0;
                        else
                            foodbank.Distance = Double.Parse(distance);

                        result.Add(foodbank);
                    }
                    return result;
                }
            }
        }


        public List<DonationDistanceResult> GetNearbyDonations(double latitude, double longitude)
        {
            String _connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DonationContext"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.usp_GetNearDonations", connection))
                {
                    List<DonationDistanceResult> result = new List<DonationDistanceResult>();
                    command.CommandType = CommandType.StoredProcedure;
                    #region Add Parameters
                    command.Parameters.Add(new SqlParameter("@latitude", latitude));
                    command.Parameters.Add(new SqlParameter("@longitude", longitude));
                    #endregion

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DonationDistanceResult donation = new DonationDistanceResult();
                        donation.Name = reader.GetValue(0).ToString();
                        donation.Email = reader.GetValue(1).ToString();
                        donation.Phone = reader.GetValue(2).ToString();
                        donation.Address = reader.GetValue(3).ToString();
                        donation.Description = reader.GetValue(4).ToString();
                        donation.Status = reader.GetValue(5).ToString();
                        donation.ExpirationDate = (DateTime)reader.GetValue(6);

                        // Need some extra logic for when distance == 0, since double.parse returns empty string
                        String distance = reader.GetValue(7).ToString();
                        if (distance.Equals(""))
                            donation.Distance = 0.0;
                        else
                            donation.Distance = Double.Parse(distance);
                        
                        result.Add(donation);
                    }
                    return result;
                }
            }
        }

    }
}