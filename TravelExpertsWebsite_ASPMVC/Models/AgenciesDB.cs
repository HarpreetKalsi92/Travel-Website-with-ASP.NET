using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelExpertsWebsite_ASPMVC.Models
{
    public class AgenciesDB
    {

        
        public static List<Agency> GetAgencies()
        {
            List<Agency> AgencyList = new List<Agency>();
            string sql = "SELECT AgencyId, AgncyAddress, AgncyCity,AgncyProv,AgncyPostal,AgncyCountry,AgncyPhone,AgncyFax "
                + "FROM Agencies ORDER BY AgencyId";
            using (SqlConnection con = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Agency agency;
                    while (dr.Read())
                    {
                        agency = new Agency();
                        agency.AgencyId = Convert.ToInt32(dr["AgencyId"]);
                        agency.AgncyAddress = dr["AgncyAddress"].ToString();
                        agency.AgncyCity = dr["AgncyCity"].ToString();
                        agency.AgncyProv = dr["AgncyProv"].ToString();
                        agency.AgncyPostal = dr["AgncyPostal"].ToString();
                        agency.AgncyCountry = dr["AgncyCountry"].ToString();
                        agency.AgncyPhone = dr["AgncyPhone"].ToString();
                        agency.AgncyFax = dr["AgncyFax"].ToString();
                        AgencyList.Add(agency);
                    }
                    dr.Close();
                }
            }
            return AgencyList;
        }
        public static Agency GetAgencyByID(string AgcyID)
        {
            Agency agency = null;
            string sql = "SELECT AgencyId, AgncyAddress, AgncyCity,AgncyProv,AgncyPostal,AgncyCountry,AgncyPhone,AgncyFax "
                + "FROM Agencies WHERE AgencyId = @AgencyId";
            using (SqlConnection con = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@AgencyId", AgcyID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        agency = new Agency();
                        agency.AgencyId = Convert.ToInt32(dr["AgencyId"]);
                        agency.AgncyAddress = dr["AgncyAddress"].ToString();
                        agency.AgncyCity = dr["AgncyCity"].ToString();
                        agency.AgncyProv = dr["AgncyProv"].ToString();
                        agency.AgncyPostal = dr["AgncyPostal"].ToString();
                        agency.AgncyCountry = dr["AgncyCountry"].ToString();
                        agency.AgncyPhone = dr["AgncyPhone"].ToString();
                        agency.AgncyFax = dr["AgncyFax"].ToString();

                    }
                    dr.Close();
                }
            }
            return agency;
        }

    }
}