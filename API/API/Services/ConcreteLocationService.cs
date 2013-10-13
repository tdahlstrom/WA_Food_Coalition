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

        public List<FoodBank> GetNearbyFoodBanks(double latitude, double longitude, int amountToReturn)
        {
            String _connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.usp_GetNearDonations", connection))
                {
                    List<FoodBank> result = new List<FoodBank>();
                    command.CommandType = CommandType.StoredProcedure;
                    #region Add Parameters
                    command.Parameters.Add(new SqlParameter("@latitude", latitude));
                    command.Parameters.Add(new SqlParameter("@longitude", longitude));
                    #endregion

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        FoodBank foodbank = new FoodBank();
                        foodbank.Name = reader.GetValue(0).ToString();
                        foodbank.Email = reader.GetValue(1).ToString();
                        result.Add(foodbank);
                    }
                    return result;
                }
            }
        }


        public List<Donation> GetNearbyDonations(double latitude, double longitude)
        {
            String _connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.usp_GetNearDonations", connection))
                {
                    List<Donation> result = new List<Donation>();
                    command.CommandType = CommandType.StoredProcedure;
                    #region Add Parameters
                    command.Parameters.Add(new SqlParameter("@latitude", latitude));
                    command.Parameters.Add(new SqlParameter("@longitude", longitude));
                    #endregion

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Donation donation = new Donation();
                        donation.Name = reader.GetValue(0).ToString();
                        donation.Email = reader.GetValue(1).ToString();
                        donation.Phone = reader.GetValue(2).ToString();
                        donation.Address = reader.GetValue(3).ToString();
                        donation.Description = reader.GetValue(4).ToString();
                        donation.Status = reader.GetValue(5).ToString();
                        donation.ExpirationDate = (DateTime)reader.GetValue(6);
                        result.Add(donation);
                    }
                    return result;
                }
            }
        }

    }
}