using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace KillTheTest.Models
{
    public class Sections : Dictionary<int, Section>
    {
        /// <summary>
        /// Get All sections, with full underlying structures  (Units, SubTopics, Objectives, Lessons) 
        /// </summary>
        public void GetSectionsFull(string userId)
        {
            this.Clear();

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
                    command.CommandText = "dbo.get_sections_full";
                    command.Parameters.AddWithValue("user_id",userId);
                    
                    SqlDataReader dr = command.ExecuteReader();

                    int sectionId = 0;
                    int unitId = 0;
                    int subTopicId = 0;
                    int objectiveId = 0;
                    int lessonId = 0;
                    while (dr.Read())
                    {
                        sectionId = 0;
                        unitId = 0;
                        subTopicId = 0;
                        objectiveId = 0;
                        lessonId = 0;

                        sectionId = int.Parse(dr["section_id"].ToString());
                        if (dr["unit_id"] != DBNull.Value)
                        {
                            unitId = int.Parse(dr["unit_id"].ToString());
                        }
                        if (dr["subtopic_id"] != DBNull.Value)
                        {
                            subTopicId = int.Parse(dr["subtopic_id"].ToString());
                        }
                        if (dr["objective_id"] != DBNull.Value)
                        {
                            objectiveId = int.Parse(dr["objective_id"].ToString());
                        }
                        if (dr["lesson_id"] != DBNull.Value)
                        {
                            lessonId = int.Parse(dr["lesson_id"].ToString());
                        }

                        //Add section if not already in there
                        if (!this.ContainsKey(sectionId))
                        {
                            Section s = new Section();
                            s.SectionId = int.Parse(dr["section_id"].ToString());
                            s.SectionName = dr["section_name"].ToString();
                            s.SectionUrl = dr["section_url"].ToString();
                            s.SectionDescription = dr["section_description"].ToString();
                            this.Add(sectionId, s);
                        }

                        //Add Unit if not already in there
                        if (unitId != 0)
                        {
                            if (!this[sectionId].Units.ContainsKey(unitId))
                            {
                                Unit u = new Unit();
                                u.UnitId = int.Parse(dr["unit_id"].ToString());
                                u.UnitName = dr["unit_name"].ToString();
                                u.UnitUrl = dr["unit_url"].ToString();
                                u.UnitDescription = dr["unit_description"].ToString();
                                this[sectionId].Units.Add(unitId, u);
                            }
                        }

                        //Add Subtopic if not already in there
                        if (subTopicId != 0)
                        {                           
                            if (!this[sectionId].Units[unitId].SubTopics
                                .ContainsKey(subTopicId))
                            {
                                SubTopic st = new SubTopic();
                                st.SubTopicId = int.Parse(dr["subtopic_id"].ToString());
                                st.SubTopicName = dr["subtopic_name"].ToString();
                                st.SubTopicUrl = dr["subtopic_url"].ToString();
                                st.SubtopicDescription = dr["subtopic_description"].ToString();
                                this[sectionId].Units[unitId].SubTopics.Add(subTopicId, st);
                            }
                        }
                        //Add Objective if not already in there
                        if (objectiveId != 0)
                        { 
                            if (!this[sectionId].Units[unitId].SubTopics[subTopicId].Objectives
                                .ContainsKey(objectiveId) )
                            {
                                Objective o = new Objective();
                                o.ObjectiveId = int.Parse(dr["objective_id"].ToString());
                                o.ObjectiveName = dr["objective_name"].ToString();
                                o.ObjectiveUrl = dr["objective_url"].ToString();
                                o.ObjectiveDescription = dr["objective_description"].ToString();
                                o.Completed = !(dr["user_id"]==DBNull.Value);//There was a completed record for this user
                                this[sectionId].Units[unitId].SubTopics[subTopicId].Objectives.Add(objectiveId, o);
                            }
                        }

                        if (lessonId != 0)
                        {
                            //Add lesson
                            Lesson l = new Lesson();
                            l.LessonId = int.Parse(dr["lesson_id"].ToString());
                            l.LessonName = dr["lesson_name"].ToString();
                            l.LessonText = dr["lesson_text"].ToString();
                            l.LessonQuestion = dr["lesson_question"].ToString();
                            l.LessonAnswer = dr["lesson_answer"].ToString();
                            l.LessonExplanation = dr["lesson_explanation"].ToString();
                            l.LessonUrl = dr["lesson_url"].ToString();
                            this[sectionId].Units[unitId].SubTopics[subTopicId].Objectives[objectiveId]
                                .Lessons.Add(lessonId, l);
                        }
                    }

                    connection.Close();
                }

            }
        }
    }
}