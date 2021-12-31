using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelExpertsWebsite_ASPMVC.Models
{
    public static class TravelExpertsDB
    {
        public static SqlConnection GetConnection()
        {
            //Public method to connect to TravelExperts database
            //Returns SqlConnection

            string connectionString = @"Data Source = localhost\SQLEXPRESS; Initial Catalog = TravelExperts; Integrated Security = True";
            return new SqlConnection(connectionString);
        }
    }
}
