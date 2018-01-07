using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillTheTest.Models;
namespace KillTheTest.Controllers
{
    public class LessonsController : Controller
    {
        // GET: Lesson
        public ActionResult Index()
        {

            Sections sections = new Sections();
            sections.GetSectionsFull(UserId);
            return View(sections);
        }

        public ActionResult Directory()
        {

            Sections sections = new Sections();
            sections.GetSectionsFull(UserId);
            return View(sections);
        }


        public ActionResult StudentLesson(string url)
        {
            KillTheTest.Models.Lesson lesson
                = new KillTheTest.Models.Lesson();
            lesson.LessonUrl = url;
            lesson.GetLessonByUrl();
            lesson.GetLessonsInObjective(UserId);
            return View("LessonDetails", lesson);
        }


        public ActionResult TeacherLesson(string url)
        {
            KillTheTest.Models.Lesson lesson
                = new KillTheTest.Models.Lesson();
            lesson.LessonUrl = url;
            lesson.GetLessonByUrl();
            lesson.GetLessonsInObjective(UserId);
            return View("LessonDetailsTeacher", lesson);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            KillTheTest.Models.Lesson lesson
                = new KillTheTest.Models.Lesson();
            lesson.LessonId = id;
            lesson.GetLesson(UserId);
            return View("Edit", lesson);
        }

        public ActionResult SectionDetails(string url)
        {

            Sections sections = new Sections();
            sections.GetSectionsFull(UserId);

            foreach (Section s in sections.Values)
            {
                if (s.SectionUrl.ToUpper() == url.ToUpper())
                {
                    return View("SectionDetails",s);
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Lesson l)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", l);
            }

            l.SaveLesson();

            return RedirectToAction("Index");
        }


        public ActionResult ObjectiveHandout(int id)
        {
            KillTheTest.Models.Objective objective
                = new KillTheTest.Models.Objective();

            objective.ObjectiveId = id;
            objective.GetObjective();
            objective.GetLessons();
            return View("ObjectiveHandout", objective);
        }



        [HttpGet]
        [Route("Lessons/{section}/{topic}/{subtopic}/{id:int}/Create")]
        public ActionResult Create(int id)
        {
            KillTheTest.Models.Lesson lesson
                = new KillTheTest.Models.Lesson();
            lesson.ObjectiveId = id;

            return View("Create", lesson);
        }


        [HttpPost]
        [Route("Lessons/{section}/{topic}/{subtopic}/{id:int}/Create")]
        public ActionResult Create(Lesson l)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", l);
            }

            l.SaveLesson();

            return RedirectToAction("Index");
        }

        public ActionResult UserComplete(int id)
        {

                KillTheTest.Models.Lesson lesson
                = new KillTheTest.Models.Lesson();
                lesson.LessonId = id;
                lesson.PutUserComplete(UserId);            
            return Json(new { success = true });
        }

        public ActionResult ObjectiveComplete(int id)
        {
            KillTheTest.Models.Objective objective
                = new KillTheTest.Models.Objective();
            objective.ObjectiveId = id;
            objective.GetObjective();
            objective.GetObjectivesInSubtopic();
            objective.GetLessons();
            objective.PutUserComplete(UserId);
            return View("ObjectiveComplete", objective);
        }

        public ActionResult ObjectiveDetails(int id)
        {
            KillTheTest.Models.Objective objective
                = new KillTheTest.Models.Objective();
            objective.ObjectiveId = id;
            objective.GetObjective();
            objective.GetLessons();
            return View("ObjectiveDetails", objective);
        }



        [HttpGet]
        [Route("Lessons/{section}/{topic}/{id:int}/Create")]
        public ActionResult ObjectiveCreate(int id)
        {
            KillTheTest.Models.Objective o
                = new KillTheTest.Models.Objective();
            o.SubTopicId = id;

            return View("Create", o);
        }


        [HttpPost]
        [Route("Lessons/{section}/{topic}/{id:int}/Create")]
        public ActionResult ObjectiveCreate(Objective o)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", o);
            }

            o.SaveObjective();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Lessons/{section}/{topic}/{subtopic}/{id:int}/Edit")]
        public ActionResult ObjectiveEdit(int id)
        {
            KillTheTest.Models.Objective o
                = new KillTheTest.Models.Objective();
            o.ObjectiveId = id;
            o.GetObjective();
            return View("Edit", o);
        }


        [HttpPost]
        [Route("Lessons/{section}/{topic}/{subtopic}/{id:int}/Edit")]
        public ActionResult ObjectiveEdit(Objective o)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", o);
            }

            o.SaveObjective();

            return RedirectToAction("Index", "Lessons");
        }

        // GET: Objective/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Objective/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public string UserId
        {
            get
            {
                if (User.Identity.Name != "")
                {
                    return User.Identity.Name;
                }
                else
                {

                    return Session.SessionID;
                }
            }
        }

    }
}