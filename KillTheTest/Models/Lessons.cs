using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace KillTheTest.Models
{
    public class Objectives:List <Objective>
    {


        /// <summary>
        /// Get All Lessons from DB
        /// </summary>
        public void GetObjectives()
        {

            //Get Connection from config file
            string connString = System.Configuration.ConfigurationManager.
                ConnectionStrings["killthetest"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandTimeout = 0;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "dbo.get_objectives";

                    SqlDataReader dr = command.ExecuteReader();
                    
                    while (dr.Read())
                    {
                        Objective l = new Objective();
                        l.ObjectiveId = int.Parse(dr["objective_id"].ToString());
                        l.ObjectiveName = dr["objective_name"].ToString();
                        l.ObjectiveUrl = dr["objective_url"].ToString();
                        l.SectionId = int.Parse(dr["section_id"].ToString());
                        l.SectionName = dr["section_name"].ToString();
                        l.SectionUrl = dr["section_url"].ToString();
                        l.UnitId = int.Parse(dr["unit_id"].ToString());
                        l.UnitName = dr["unit_name"].ToString();
                        l.UnitUrl = dr["unit_url"].ToString();
                        l.SubTopicId = int.Parse(dr["subtopic_id"].ToString());
                        l.SubTopicName = dr["subtopic_name"].ToString();
                        l.SubTopicUrl = dr["subtopic_url"].ToString();
                        this.Add(l);//add to collection
                    }

                    connection.Close();
                }
            }

        }

    }
}