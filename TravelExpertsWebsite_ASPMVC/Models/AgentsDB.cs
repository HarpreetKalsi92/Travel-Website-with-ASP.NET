using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TravelExpertsWebsite_ASPMVC.Models
{
    public class AgentsDB
    {

        public static List<Agent> GetAgent()
        {
            List<Agent> AgentList = new List<Agent>();
            string sql = "SELECT AgentId, AgtFirstName, AgtMiddleInitial,AgtLastName,AgtBusPhone,AgtEmail,AgtPosition,AgencyId "
                + "FROM Agents ORDER BY AgentId";
            using (SqlConnection con = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Agent agent;
                    while (dr.Read())
                    {
                        agent = new Agent();
                        agent.AgentId = Convert.ToInt32(dr["AgentId"]);
                        agent.AgtFirstName = dr["AgtFirstName"].ToString();
                        agent.AgtMiddleInitial = dr["AgtMiddleInitial"].ToString();
                        agent.AgtLastName = dr["AgtLastName"].ToString();
                        agent.AgtBusPhone = dr["AgtBusPhone"].ToString();
                        agent.AgtEmail = dr["AgtEmail"].ToString();
                        agent.AgtPosition = dr["AgtPosition"].ToString();

                        // nullable
                        int col = dr.GetOrdinal("AgencyId");
                        if (dr.IsDBNull(col))
                            agent.AgencyId = null;
                        else
                            agent.AgencyId = Convert.ToInt32( dr["AgencyId"]);

                        AgentList.Add(agent);
                    }
                    dr.Close();
                }
            }
            return AgentList;
        }
        public static Agent GetAgentByID(string AgntID)
        {
            Agent agent = null;
            string sql = " SELECT AgentId, AgtFirstName, AgtMiddleInitial,AgtLastName,AgtBusPhone,AgtEmail,AgtPosition,AgencyId"
                + "FROM Agents WHERE AgentId = @AgentId";
            using (SqlConnection con = TravelExpertsDB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@AgentId", AgntID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        agent = new Agent();
                        agent.AgentId = Convert.ToInt32(dr["AgentId"]);
                        agent.AgtFirstName = dr["AgtFirstName"].ToString();
                        agent.AgtMiddleInitial = dr["AgtMiddleInitial"].ToString();
                        agent.AgtLastName = dr["AgtLastName"].ToString();
                        agent.AgtBusPhone = dr["AgtBusPhone"].ToString();
                        agent.AgtEmail = dr["AgtEmail"].ToString();
                        agent.AgtPosition = dr["AgtPosition"].ToString();

                        // nullable
                        int col = dr.GetOrdinal("AgencyId");
                        if (dr.IsDBNull(col))
                            agent.AgencyId = null;
                        else
                            agent.AgencyId = Convert.ToInt32(dr["AgencyId"]);

                    }
                    dr.Close();
                }
            }
            return agent;
        }

    }
}