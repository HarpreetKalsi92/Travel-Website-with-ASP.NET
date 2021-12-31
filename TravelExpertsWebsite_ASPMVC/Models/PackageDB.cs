using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelExpertsWebsite_ASPMVC.Models
{
    /*
   *Author: Jaswinder Sangha
   *Date: Aug 5th, 2019
   */

    public static class PackagesDB
    {
        //Retrieve all the packages from database
        public static List<Package> GetPackages()
        {
            List<Package> lstPackages = new List<Package>();

            string selectQuery = "select * from packages";
            using (SqlConnection con = TravelExpertsDB.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(selectQuery, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Package pack = new Package();
                    pack.PackageId = Convert.ToInt32(dr["PackageId"]);
                    pack.PkgName = dr["PkgName"].ToString();
                    pack.PkgBasePrice = Convert.ToDecimal(dr["PkgBasePrice"].ToString());

                    int colDesc = dr.GetOrdinal("PkgDesc");
                    if (dr.IsDBNull(colDesc))
                        pack.PkgDesc = "";
                    else
                        pack.PkgDesc = dr["PkgDesc"].ToString();

                    int colImage = dr.GetOrdinal("PkgImage");
                    if (dr.IsDBNull(colImage))
                        pack.PkgImage = "";
                    else
                        pack.PkgImage = dr["PkgImage"].ToString();

                    lstPackages.Add(pack);
                }
            }
            return lstPackages;
        }

        //Retrieve package from database based on package selected by customer
        public static Package GetPackagesById(int id)
        {
            Package pack = new Package();

            string selectQuery = "select * from packages where packageId = @pid";
            using (SqlConnection con = TravelExpertsDB.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(selectQuery, con);
                cmd.Parameters.AddWithValue("@pid", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    pack.PackageId = Convert.ToInt32(dr["PackageId"]);
                    pack.PkgName = dr["PkgName"].ToString();
                    pack.PkgBasePrice = Convert.ToDecimal(dr["PkgBasePrice"].ToString());

                    int col1 = dr.GetOrdinal("PkgDesc");
                    if (dr.IsDBNull(col1))
                        pack.PkgDesc = "";
                    else
                        pack.PkgDesc = dr["PkgDesc"].ToString();
                }
            }
            return pack;
        }
    }
}
