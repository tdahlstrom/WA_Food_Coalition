using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Services
{
    public class ExpirationService
    {
        public int CloseExpiredDonations()
        {
            String _connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DonationContext"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("dbo.usp_CloseExpiredDonations", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                int numAffected = command.ExecuteNonQuery();
                return numAffected;
            }
        }
    }
}