using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace KillTheTest.Models
{
    public class Lesson
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


        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonText { get; set; }
        public string LessonQuestion { get; set; }
        public string LessonAnswer { get; set; }
        public string LessonExplanation { get; set; }
        public string LessonHint { get; set; }
        public string LessonUrl { get; set; }

        public int LessonType { get; set; }

        public string LessonDescription { get; set; }

        public string LessonFocusSentence { get; set; }

        public bool UserCompleted { get; set; }

        public List<Lesson> LessonsInObjective = new List<Lesson>();


        public string LessonTextFormatted
        {
            get
            {
                return @LessonText.Replace(System.Environment.NewLine, "<br />");
            }
        }
        public string LessonQuestionFormatted
        {
            get
            {
                return @LessonQuestion.Replace(System.Environment.NewLine, "<br />");
            }
        }

        public void GetLesson(string userId)
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
                    command.CommandText = "dbo.get_lesson";
                    command.Parameters.AddWithValue("lesson_id", LessonId);
                    command.Parameters.AddWithValue("user_id", userId);

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Objective l = new Objective();
                        ObjectiveId = int.Parse(dr["objective_id"].ToString());
                        ObjectiveName = dr["objective_name"].ToString();
                        ObjectiveUrl = dr["objective_url"].ToString();
                        SectionId = int.Parse(dr["section_id"].ToString());
                        SectionName = dr["section_name"].ToString();
                        SectionUrl = dr["section_url"].ToString();
                        UnitId = int.Parse(dr["unit_id"].ToString());
                        UnitName = dr["unit_name"].ToString();
                        UnitUrl = dr["unit_url"].ToString();
                        SubTopicId = int.Parse(dr["subtopic_id"].ToString());
                        SubTopicName = dr["subtopic_name"].ToString();
                        SubTopicUrl = dr["subtopic_url"].ToString();
                        LessonId = int.Parse(dr["lesson_id"].ToString());
                        LessonQuestion = dr["lesson_question"].ToString();
                        LessonName = dr["lesson_name"].ToString();
                        LessonExplanation = dr["lesson_explanation"].ToString();
                        LessonText = dr["lesson_text"].ToString();
                        LessonAnswer = dr["lesson_answer"].ToString();
                        LessonHint = dr["lesson_hint"].ToString();
                        LessonUrl = dr["lesson_url"].ToString();
                        LessonType = int.Parse(dr["lesson_type"].ToString());
                        LessonFocusSentence = dr["lesson_focus_sentence"].ToString();
                        LessonDescription = dr["lesson_description"].ToString();
                        UserCompleted = dr["user_id"] != DBNull.Value;
                    }

                    connection.Close();
                }
            }
        }

        public void GetLessonByUrl()
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
                    command.CommandText = "dbo.get_Lesson_by_url";
                    command.Parameters.AddWithValue("Lesson_url", LessonUrl);

                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        Objective l = new Objective();
                        ObjectiveId = int.Parse(dr["objective_id"].ToString());
                        ObjectiveName = dr["objective_name"].ToString();
                        ObjectiveUrl = dr["objective_url"].ToString();
                        SectionId = int.Parse(dr["section_id"].ToString());
                        SectionName = dr["section_name"].ToString();
                        SectionUrl = dr["section_url"].ToString();
                        UnitId = int.Parse(dr["unit_id"].ToString());
                        UnitName = dr["unit_name"].ToString();
                        UnitUrl = dr["unit_url"].ToString();
                        SubTopicId = int.Parse(dr["subtopic_id"].ToString());
                        SubTopicName = dr["subtopic_name"].ToString();
                        SubTopicUrl = dr["subtopic_url"].ToString();
                        LessonId = int.Parse(dr["lesson_id"].ToString());
                        LessonQuestion = dr["lesson_question"].ToString();
                        LessonName = dr["lesson_name"].ToString();
                        LessonExplanation = dr["lesson_explanation"].ToString();
                        LessonText = dr["lesson_text"].ToString();
                        LessonAnswer = dr["lesson_answer"].ToString();
                        LessonHint = dr["lesson_hint"].ToString();
                        LessonUrl = dr["lesson_url"].ToString();
                        LessonType = int.Parse(dr["lesson_type"].ToString());
                        LessonFocusSentence = dr["lesson_focus_sentence"].ToString();
                        LessonDescription = dr["lesson_description"].ToString();
                    }

                    connection.Close();
                }

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
                    command.CommandText = "dbo.put_user_lesson";
                    command.Parameters.AddWithValue("lesson_id", LessonId);
                    command.Parameters.AddWithValue("user_id", userId);
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }


        public void SaveLesson()
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
                    command.CommandText = "dbo.put_lesson";
                    command.Parameters.AddWithValue("lesson_id", LessonId);
                    command.Parameters.AddWithValue("lesson_order", 1);
                    command.Parameters.AddWithValue("lesson_name", LessonName);
                    command.Parameters.AddWithValue("lesson_description", "Description Here");
                    command.Parameters.AddWithValue("lesson_image", "");
                    command.Parameters.AddWithValue("lesson_text", LessonText);
                    command.Parameters.AddWithValue("lesson_question", LessonQuestion);
                    command.Parameters.AddWithValue("lesson_answer", LessonAnswer);
                    command.Parameters.AddWithValue("lesson_explanation", LessonExplanation);
                    command.Parameters.AddWithValue("lesson_hint", LessonHint);
                    command.Parameters.AddWithValue("lesson_url", LessonUrl);
                    command.Parameters.AddWithValue("objective_id", ObjectiveId);
                    command.Parameters.AddWithValue("lesson_focus_sentence", LessonFocusSentence);

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }

        public void GetLessonsInObjective(string userId)
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
                    command.CommandText = "dbo.get_objective_lessons";
                    command.Parameters.AddWithValue("objective_id", ObjectiveId);

                    SqlDataReader dr = command.ExecuteReader();
                    int lessonId = 0;
                    while (dr.Read())
                    {
                        lessonId = int.Parse(dr["lesson_id"].ToString());
                        Lesson l = new Lesson();
                        l.LessonId = lessonId;
                        l.GetLesson(userId);
                        LessonsInObjective.Add(l);
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
        public Lesson NextLesson()
        {
            bool useNext = false;
            foreach (Lesson l in LessonsInObjective)//assume sortted by order
            {
                if (l.LessonId == LessonId)
                {
                    useNext = true;
                }
                else if (useNext)
                {
                    return l;
                }
            }
            return null; //Last lesson?
        }

        public Lesson PreviousLesson()
        {

            Lesson previousId =null;

            foreach (Lesson l in LessonsInObjective)//assume sortted by order
            {

                if (l.LessonId == LessonId)
                {
                    return previousId;
                }
                else
                {
                    previousId = l;
                }
            }
            return null; //First lesson?
        }

        /// <summary>
        /// TODO: There are faster ways to calculate this
        /// </summary>
        public decimal PercentComplete
        {
            get
            {
                int j = 0;
                foreach (Lesson l in LessonsInObjective)//assume sortted by order
                {   
                    if (l.LessonId == LessonId)
                    {
                        return Math.Round(((decimal)j / LessonsInObjective.Count*100));
                    }
                   j++;
                }
                return 0; //Last lesson?
            }
        }

        public decimal SuccessPercentComplete
        {
            get
            {
                if (LessonsInObjective.Count > 0)
                {
                    return Math.Round(PercentComplete + 100 / LessonsInObjective.Count);
                }
                else
                {
                    return 0;
                }
            }
        }


    }





}