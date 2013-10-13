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
                        foodbank.Distance = (Double)reader.GetValue(2);
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
                        donation.Distance = (Double)reader.GetValue(7);
                        result.Add(donation);
                    }
                    return result;
                }
            }
        }

    }
}