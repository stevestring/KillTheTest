using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace KillTheTest.Models
{
    public class Practice
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


        public int PracticeId { get; set; }
        public string PracticeName { get; set; }
        public string PracticeText { get; set; }
        public string PracticeQuestion { get; set; }

        public string PracticeChoiceA { get; set; }
        public string PracticeChoiceB { get; set; }
        public string PracticeChoiceC { get; set; }
        public string PracticeChoiceD { get; set; }
        public string PracticeChoiceE { get; set; }

        public string PracticeAnswer { get; set; }
        public string PracticeExplanation { get; set; }
        public string PracticeHint { get; set; }
        public string PracticeUrl { get; set; }

        public int PracticeType { get; set; }

        public string PracticeDescription { get; set; }

        public string PracticeFocusSentence { get; set; }

        public bool UserCompleted { get; set; }

        public List<Practice> PracticesInObjective = new List<Practice>();

        public List<string> letters = new List<string>(){"A","B","C","D","E"};

        public string PracticeTextFormatted
        {
            get
            {
                return @PracticeText.Replace(System.Environment.NewLine, "<br />");
            }
        }
        public string PracticeQuestionFormatted
        {
            get
            {
                return @PracticeQuestion.Replace(System.Environment.NewLine, "<br />");
            }
        }

        public void GetPractice(string userId)
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
                    command.CommandText = "dbo.get_Practice";
                    command.Parameters.AddWithValue("Practice_id", PracticeId);
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
                        PracticeId = int.Parse(dr["Practice_id"].ToString());
                        PracticeQuestion = dr["Practice_question"].ToString();
                        PracticeName = dr["Practice_name"].ToString();
                        PracticeExplanation = dr["Practice_explanation"].ToString();
                        PracticeText = dr["Practice_text"].ToString();
                        PracticeAnswer = dr["Practice_answer"].ToString();
                        PracticeHint = dr["Practice_hint"].ToString();
                        PracticeUrl = dr["Practice_url"].ToString();
                        PracticeType = int.Parse(dr["Practice_type"].ToString());
                        PracticeFocusSentence = dr["Practice_focus_sentence"].ToString();
                        PracticeDescription = dr["Practice_description"].ToString();
                        UserCompleted = dr["user_id"] != DBNull.Value;
                    }

                    connection.Close();
                }
            }
        }

        public void GetPracticeByUrl()
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
                    command.CommandText = "dbo.get_Practice_by_url";
                    command.Parameters.AddWithValue("Practice_url", PracticeUrl);

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
                        PracticeId = int.Parse(dr["Practice_id"].ToString());
                        PracticeQuestion = dr["Practice_question"].ToString();
                        PracticeName = dr["Practice_name"].ToString();
                        PracticeExplanation = dr["Practice_explanation"].ToString();
                        PracticeText = dr["Practice_text"].ToString();
                        PracticeAnswer = dr["Practice_answer"].ToString();
                        PracticeHint = dr["Practice_hint"].ToString();
                        PracticeUrl = dr["Practice_url"].ToString();
                        PracticeChoiceA = dr["Practice_choice_a"].ToString();
                        PracticeChoiceB = dr["Practice_choice_b"].ToString();
                        PracticeChoiceC = dr["Practice_choice_c"].ToString();
                        PracticeChoiceD = dr["Practice_choice_d"].ToString();
                        PracticeChoiceE = dr["Practice_choice_e"].ToString();

                        //PracticeType = int.Parse(dr["Practice_type"].ToString());
                        //PracticeFocusSentence = dr["Practice_focus_sentence"].ToString();
                        //PracticeDescription = dr["Practice_description"].ToString();
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
                    command.CommandText = "dbo.put_user_Practice";
                    command.Parameters.AddWithValue("Practice_id", PracticeId);
                    command.Parameters.AddWithValue("user_id", userId);
                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }


        public void SavePractice()
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
                    command.CommandText = "dbo.put_Practice";
                    command.Parameters.AddWithValue("Practice_id", PracticeId);
                    command.Parameters.AddWithValue("Practice_order", 1);
                    command.Parameters.AddWithValue("Practice_name", PracticeName);
                    command.Parameters.AddWithValue("Practice_description", "Description Here");
                    command.Parameters.AddWithValue("Practice_image", "");
                    command.Parameters.AddWithValue("Practice_text", PracticeText);
                    command.Parameters.AddWithValue("Practice_question", PracticeQuestion);
                    command.Parameters.AddWithValue("Practice_answer", PracticeAnswer);
                    command.Parameters.AddWithValue("Practice_explanation", PracticeExplanation);
                    command.Parameters.AddWithValue("Practice_hint", PracticeHint);
                    command.Parameters.AddWithValue("Practice_url", PracticeUrl);
                    command.Parameters.AddWithValue("objective_id", ObjectiveId);
                    command.Parameters.AddWithValue("Practice_focus_sentence", PracticeFocusSentence);

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }

        public void GetPracticesInObjective(string userId)
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
                    command.CommandText = "dbo.get_objective_Practices";
                    command.Parameters.AddWithValue("objective_id", ObjectiveId);

                    SqlDataReader dr = command.ExecuteReader();
                    int PracticeId = 0;
                    while (dr.Read())
                    {
                        PracticeId = int.Parse(dr["Practice_id"].ToString());
                        Practice l = new Practice();
                        l.PracticeId = PracticeId;
                        l.GetPractice(userId);
                        PracticesInObjective.Add(l);
                    }

                    connection.Close();
                }
            }
        }
        /// <summary>
        /// Get Next Practice ID for "Next" button
        /// TODO: There are better ways to do this.
        /// </summary>
        /// <returns></returns>
        public Practice NextPractice()
        {
            bool useNext = false;
            foreach (Practice l in PracticesInObjective)//assume sortted by order
            {
                if (l.PracticeId == PracticeId)
                {
                    useNext = true;
                }
                else if (useNext)
                {
                    return l;
                }
            }
            return null; //Last Practice?
        }

        public Practice PreviousPractice()
        {

            Practice previousId =null;

            foreach (Practice l in PracticesInObjective)//assume sortted by order
            {

                if (l.PracticeId == PracticeId)
                {
                    return previousId;
                }
                else
                {
                    previousId = l;
                }
            }
            return null; //First Practice?
        }

        /// <summary>
        /// TODO: There are faster ways to calculate this
        /// </summary>
        public decimal PercentComplete
        {
            get
            {
                int j = 0;
                foreach (Practice l in PracticesInObjective)//assume sortted by order
                {   
                    if (l.PracticeId == PracticeId)
                    {
                        return Math.Round(((decimal)j / PracticesInObjective.Count*100));
                    }
                   j++;
                }
                return 0; //Last Practice?
            }
        }

        public decimal SuccessPercentComplete
        {
            get
            {
                if (PracticesInObjective.Count > 0)
                {
                    return Math.Round(PercentComplete + 100 / PracticesInObjective.Count);
                }
                else
                {
                    return 0;
                }
            }
        }


    }





}