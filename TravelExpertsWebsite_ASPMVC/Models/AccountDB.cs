using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace TravelExpertsWebsite_ASPMVC.Models
{
    public class AccountDB
    {
        /// <summary>
        /// Written by Darren Uong
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>

        //Method to validate login credentials
        public static bool ValidAccount(Login login)
        {
            bool success = false;
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string selectQuery = "SELECT * FROM Customers WHERE CustAccount = @CustAccount";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection)) { 
                    cmd.Parameters.AddWithValue("@CustAccount", login.userAccount);

                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows) //if a line is read
                        {

                            success = true; //if row select query returns an entry, return true                        
                        }
                        else //no line is read
                        {
                            success = false;
                        }
                    }
            }
                

           }
            return success;
        }

        //Method to insert new customer into database, and create login credentials
        public static string CreateUser(Customer customer)
        {
            //status of sql insert query
            string status = "failed";
            ////Hash password
            string hashed = Crypto.Hash(customer.CustPassword, "MD5");


            Login login = new Login();
            login.userAccount = customer.CustAccount;
            login.userPassword = customer.CustPassword;
            if (AccountDB.ValidAccount(login) == true)
            {
                //if account exists already
                status = "exists";

                return status;
            }
            else
            {
               using (SqlConnection connection = TravelExpertsDB.GetConnection())
                {
                    string insertQuery = "INSERT INTO Customers " +
                        " (CustFirstName, CustLastName, CustAddress, CustCity, CustProv, CustPostal, CustCountry, CustHomePhone, " +
                        " CustBusPhone, CustAccount, CustEmail, CustPassword)" +
                         "VALUES (@CustFirstName, @CustLastname, @CustAddress, @CustCity, @CustProv, @CustPostal, @CustCountry," +
                        " @CustHomePhone, @CustBusPhone, @CustAccount, @CustEmail, @CustPassword)";
                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@CustFirstName", customer.CustFirstName);
                    cmd.Parameters.AddWithValue("@CustLastName", customer.CustLastName);
                    cmd.Parameters.AddWithValue("@CustAddress", customer.CustAddress);
                    cmd.Parameters.AddWithValue("@CustCity", customer.CustCity);
                    cmd.Parameters.AddWithValue("@CustProv", customer.CustProv);
                    cmd.Parameters.AddWithValue("@CustPostal", customer.CustPostal);
                    cmd.Parameters.AddWithValue("@CustCountry", customer.CustCountry);
                    cmd.Parameters.AddWithValue("@CustHomePhone", customer.CustHomePhone);
                    if (customer.CustBusPhone == null)
                    {
                        cmd.Parameters.AddWithValue("@CustBusPhone", "");

                    }
                    else cmd.Parameters.AddWithValue("@CustBusPhone", customer.CustBusPhone);
                    cmd.Parameters.AddWithValue("@CustAccount", customer.CustAccount);
                    if (customer.CustEmail == null)
                    {
                        cmd.Parameters.AddWithValue("@CustEmail", "");

                    }else  cmd.Parameters.AddWithValue("@CustEmail", customer.CustEmail);

                    cmd.Parameters.AddWithValue("@CustPassword", hashed);



                    try
                    {
                        connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                    
                            if (RowsAffected > 0)
                            {
                                status = "created"; //if row select query returns an entry, return true
                            }
                            else
                            {
                                 status = "failed";
                            }
                    
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
                return status;
            }
        }//end CreateUser

        public static bool EditUser(Customer customer)
        {
            bool success = false;
            ////Hash password
            string hashed = Crypto.Hash(customer.CustPassword, "MD5");

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateQuery = "UPDATE Customers " +
                    " SET CustFirstName = @CustFirstName, CustLastName = @CustLastName, CustAddress = @CustAddress, " +
                    " CustCity = @CustCity, CustProv = @CustProv, CustPostal = @CustPostal, CustCountry = @CustCountry, " +
                    " CustHomePhone = @CustHomePhone, CustBusPhone = @CustBusPhone, CustEmail = @CustEmail, " +
                    " CustPassword = @CustPassword " + 
                    " WHERE CustAccount = @CustAccount";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@CustFirstName", customer.CustFirstName);
                cmd.Parameters.AddWithValue("@CustLastName", customer.CustLastName);
                cmd.Parameters.AddWithValue("@CustAddress", customer.CustAddress);
                cmd.Parameters.AddWithValue("@CustCity", customer.CustCity);
                cmd.Parameters.AddWithValue("@CustProv", customer.CustProv);
                cmd.Parameters.AddWithValue("@CustPostal", customer.CustPostal);
                cmd.Parameters.AddWithValue("@CustCountry", customer.CustCountry);
                cmd.Parameters.AddWithValue("@CustHomePhone", customer.CustHomePhone);
                cmd.Parameters.AddWithValue("@CustAccount", customer.CustAccount);

                cmd.Parameters.AddWithValue("@CustPassword", hashed);
                if (customer.CustBusPhone == null)
                {
                    cmd.Parameters.AddWithValue("@CustBusPhone", "");

                }
                else cmd.Parameters.AddWithValue("@CustBusPhone", customer.CustBusPhone);
                if (customer.CustEmail == null)
                {
                    cmd.Parameters.AddWithValue("@CustEmail", "");

                }
                else cmd.Parameters.AddWithValue("@CustEmail", customer.CustEmail);



                try
                {
                    connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

            }
            return success;
        }

        public static Customer GetCustomer(string accName)
        {
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                Customer customer = new Customer();
                string selectQuery = "SELECT * FROM Customers WHERE CustAccount = @CustAccount";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                cmd.Parameters.AddWithValue("@CustAccount", accName);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    if (reader.Read()) //if a line is read
                    {
                        customer.CustFirstName = reader["CustFirstName"].ToString();
                        customer.CustLastName = reader["CustLastName"].ToString();
                        customer.CustAddress = reader["CustAddress"].ToString();
                        customer.CustCity = reader["CustCity"].ToString();
                        customer.CustPostal = reader["CustPostal"].ToString();
                        customer.CustCountry = reader["CustCountry"].ToString();
                        customer.CustHomePhone = reader["CustHomePhone"].ToString();
                        customer.CustBusPhone = reader["CustBusPhone"].ToString();
                        customer.CustEmail = reader["CustEmail"].ToString();
                        customer.CustAccount = reader["CustAccount"].ToString();
                        customer.CustPassword = reader["CustPassword"].ToString();

                    }
                    else //no line is read
                    {
                        //do nothing
                    }
                }
                return customer;
            }
        }//end GetCustomer



    }//end accountdb class
}//end namespace