using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace KillTheTest.Models
{
    public class Unit
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string SectionUrl { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public string UnitUrl { get; set; }
        public string UnitDescription { get; set; }

        public Dictionary<int, SubTopic> SubTopics = new Dictionary<int,SubTopic>();
        public void GetSubTopics()
        {
            SubTopics = new Dictionary<int, SubTopic>();

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
                    command.CommandText = "dbo.get_objective_lessons";
                    command.Parameters.AddWithValue("unit_id", UnitId);

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        SubTopic st = new SubTopic();
                        st.SubTopicId = int.Parse(dr["subtopic_id"].ToString());
                        st.SubTopicName = dr["subtopic_name"].ToString();
                        st.SubtopicDescription = dr["subtopic_description"].ToString();
                        st.SubTopicUrl = dr["subtopic_url"].ToString();

                        SubTopics.Add(st.SubTopicId,st);
                    }

                    connection.Close();
                }

            }
        }


        public void GetUnit()
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
                    command.CommandText = "dbo.get_unit";
                    command.Parameters.AddWithValue("unit_id", UnitId);

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        SectionId = int.Parse(dr["section_id"].ToString());
                        SectionName = dr["section_name"].ToString();
                        SectionUrl = dr["section_url"].ToString();
                        UnitId = int.Parse(dr["unit_id"].ToString());
                        UnitName = dr["unit_name"].ToString();
                        UnitUrl = dr["unit_url"].ToString();
                        UnitDescription = dr["unit_description"].ToString();

                    }

                    connection.Close();
                }

            }
        }
    }
}