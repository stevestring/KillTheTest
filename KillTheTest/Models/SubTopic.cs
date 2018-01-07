using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace KillTheTest.Models
{
    public class SubTopic
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string SectionUrl { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public string UnitUrl { get; set; }
        public int SubTopicId { get; set; }
        public string SubTopicName { get; set; }
        public string SubTopicUrl { get; set; }
        public string SubtopicDescription { get; set; }


        public Dictionary<int, Objective> Objectives = new  Dictionary<int,Objective>();
        public void GetLessons()
        {
            Objectives = new Dictionary<int, Objective>();

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
                    command.CommandText = "dbo.get_subtopic_objectives";
                    command.Parameters.AddWithValue("objective_id", SubTopicId);

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Objective o = new Objective();
                        o.ObjectiveId = int.Parse(dr["objective_id"].ToString());
                        o.ObjectiveName = dr["objective_name"].ToString();
                        o.ObjectiveUrl = dr["objective_url"].ToString();
                        o.ObjectiveDescription = dr["objective_description"].ToString();
                      
                        Objectives.Add(o.ObjectiveId,o);
                    }

                    connection.Close();
                }

            }
        }


        public void GetSubtopic()
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
                    command.CommandText = "dbo.get_objective";
                    command.Parameters.AddWithValue("subtopic_id", SubTopicId);

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        SectionId = int.Parse(dr["section_id"].ToString());
                        SectionName = dr["section_name"].ToString();
                        SectionUrl = dr["section_url"].ToString();
                        UnitId = int.Parse(dr["unit_id"].ToString());
                        UnitName = dr["unit_name"].ToString();
                        UnitUrl = dr["unit_url"].ToString();
                        SubTopicId = int.Parse(dr["subtopic_id"].ToString());
                        SubTopicName = dr["subtopic_name"].ToString();
                        SubTopicUrl = dr["subtopic_url"].ToString();
                        SubtopicDescription = dr["subtopic_description"].ToString();
                    }

                    connection.Close();
                }

            }
        }
    }
}