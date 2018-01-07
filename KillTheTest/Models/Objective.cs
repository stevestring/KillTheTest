using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace KillTheTest.Models
{
    public class Objective
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
        public int ObjectiveId { get; set; }
        public string ObjectiveName { get; set; }
        public string ObjectiveDescription { get; set; }
        public string ObjectiveUrl { get; set; }
        public Dictionary<int,Lesson> Lessons = new Dictionary<int,Lesson>();

        public List<Objective> ObjectivesInSubtopic = new List<Objective>();

        public bool Completed { get; set; }

        public void GetLessons()
        {
            Lessons = new Dictionary<int, Lesson>();

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
                    command.Parameters.AddWithValue("objective_id", ObjectiveId);

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Lesson lp = new Lesson();
                        lp.LessonId = int.Parse(dr["lesson_id"].ToString());
                        lp.LessonName = dr["lesson_name"].ToString();
                        lp.LessonText = dr["lesson_text"].ToString();
                        lp.LessonQuestion = dr["lesson_question"].ToString();
                        lp.LessonAnswer = dr["lesson_answer"].ToString();
                        lp.LessonExplanation = dr["lesson_explanation"].ToString();
                        lp.LessonFocusSentence = dr["lesson_focus_sentence"].ToString();
                        lp.LessonUrl = dr["lesson_url"].ToString();
                        lp.LessonHint = dr["lesson_hint"].ToString();
                        lp.LessonType = int.Parse(dr["lesson_type"].ToString());

                        Lessons.Add(lp.LessonId, lp);
                    }

                    connection.Close();
                }

            }
        }

        public void GetObjective()
        {
            GetObjective(ObjectiveId);
        }

        public void GetObjective(int objectiveId)
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
                    command.Parameters.AddWithValue("objective_id", ObjectiveId);

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Objective l = new Objective();
                        ObjectiveId = int.Parse(dr["objective_id"].ToString());
                        ObjectiveName = dr["objective_name"].ToString();
                        ObjectiveUrl = dr["objective_url"].ToString();
                        ObjectiveDescription = dr["objective_description"].ToString();
                        SectionId = int.Parse(dr["section_id"].ToString());
                        SectionName = dr["section_name"].ToString();
                        SectionUrl = dr["section_url"].ToString();
                        UnitId = int.Parse(dr["unit_id"].ToString());
                        UnitName = dr["unit_name"].ToString();
                        UnitUrl = dr["unit_url"].ToString();
                        SubTopicId = int.Parse(dr["subtopic_id"].ToString());
                        SubTopicName = dr["subtopic_name"].ToString();
                        SubTopicUrl = dr["subtopic_url"].ToString();

                    }

                    connection.Close();
                }

            }
        }


        public void SaveObjective()
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
                    command.CommandText = "dbo.put_objective";
                    command.Parameters.AddWithValue("objective_id", ObjectiveId);
                    command.Parameters.AddWithValue("objective_order", 1);
                    command.Parameters.AddWithValue("objective_name", ObjectiveName);
                    command.Parameters.AddWithValue("objective_description", ObjectiveDescription);
                    command.Parameters.AddWithValue("objective_image", "");
                    command.Parameters.AddWithValue("subtopic_id", SubTopicId);

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }

        public void GetObjectivesInSubtopic()
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
                    command.CommandText = "dbo.get_subtopic_objectives";
                    command.Parameters.AddWithValue("subtopic_id", SubTopicId);

                    SqlDataReader dr = command.ExecuteReader();                   
                    while (dr.Read())
                    {
                        Objective o = new Objective();
                        o.ObjectiveId= int.Parse(dr["objective_id"].ToString());
                        o.ObjectiveName = dr["objective_name"].ToString();
                        o.ObjectiveUrl = dr["objective_name"].ToString();
                        ObjectivesInSubtopic.Add(o);
                    }

                    connection.Close();
                }
            }
        }
        /// <summary>
        /// Get Next Lesson ID for "Next" button
        /// TODO: There are better ways to do this.
        /// </summary>
        /// <returns></returns>
        public Objective NextObjective
        {
            get
                {
                bool useNext = false;
                foreach (Objective o in ObjectivesInSubtopic)//assume sortted by order
                {
                    if (o.ObjectiveId == ObjectiveId)
                    {
                        useNext = true;
                    }
                    else if (useNext)
                    {
                        return o;
                    }
                }
                return null; //Last lesson?
                }
        }

        public void PutUserComplete(string userId)
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
                    command.CommandText = "dbo.put_user_objective";
                    command.Parameters.AddWithValue("objective_id", ObjectiveId);
                    command.Parameters.AddWithValue("user_id", userId);

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }


    }
}