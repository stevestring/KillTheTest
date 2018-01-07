using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace KillTheTest.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string SectionUrl { get; set; }
        public string SectionDescription { get; set; }

        public Dictionary<int,Unit> Units = new Dictionary<int,Unit>();
        public void GetUnits()
        {
            Units = new Dictionary<int, Unit>();

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
                    command.CommandText = "dbo.get_section_units";
                    command.Parameters.AddWithValue("section_id", SectionId);

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Unit u = new Unit();
                        u.UnitId = int.Parse(dr["unit_id"].ToString());
                        u.UnitName = dr["unit_name"].ToString();
                        u.UnitDescription = dr["unit_description"].ToString();
                        u.UnitUrl = dr["unit_url"].ToString();

                        Units.Add(u.UnitId,u);
                    }

                    connection.Close();
                }

            }
        }


        public void Getsection()
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
                    command.CommandText = "dbo.get_section";
                    command.Parameters.AddWithValue("section_id", SectionId);

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Section s = new Section();
                        SectionId = int.Parse(dr["section_id"].ToString());
                        SectionName = dr["section_name"].ToString();
                        SectionUrl = dr["section_url"].ToString();
                        SectionDescription =dr["section_description"].ToString();

                    }

                    connection.Close();
                }

            }
        }
    }
}