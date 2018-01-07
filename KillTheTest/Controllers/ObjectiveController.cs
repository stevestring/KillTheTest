using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillTheTest.Models;
namespace KillTheTest.Controllers
{
    public class ObjectiveController : Controller
    {
        // GET: Objective
        public ActionResult Index()
        {
            return View();
        }


        //public ActionResult Complete(int id)
        //{
        //    KillTheTest.Models.Objective objective
        //        = new KillTheTest.Models.Objective();
        //    objective.ObjectiveId = id;
        //    objective.GetObjective();
        //    objective.GetObjectivesInSubtopic();
        //    objective.GetLessons();
        //    objective.PutUserComplete(UserId);
        //    return View("Complete", objective);
        //}


        //[Route("Lessons/{section}/{unit}/{subtopic}/{id}")]
        //public ActionResult Details(int id)
        //{
        //    KillTheTest.Models.Objective objective
        //        = new KillTheTest.Models.Objective();
        //    objective.ObjectiveId = id;
        //    objective.GetObjective();
        //    objective.GetLessons();
        //    return View("Details", objective);
        //}

        ////[Route("Teacher/Lessons/{section}/{unit}/{subtopic}/{id}")]
        ////public ActionResult AllLessons(int id)
        ////{
        ////    KillTheTest.Models.Objective objective
        ////        = new KillTheTest.Models.Objective();
        ////    objective.ObjectiveId = id;
        ////    objective.GetObjective();
        ////    objective.GetLessons();
        ////    return View("AllLessons", objective);
        ////}


        //[HttpGet]
        //[Route("Lessons/{section}/{topic}/{id:int}/Create")]
        //public ActionResult Create(int id)
        //{
        //    KillTheTest.Models.Objective o
        //        = new KillTheTest.Models.Objective();
        //    o.SubTopicId = id;

        //    return View("Create", o);
        //}


        //[HttpPost]
        //[Route("Lessons/{section}/{topic}/{id:int}/Create")]
        //public ActionResult Create(Objective o)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Create", o);
        //    }

        //    o.SaveObjective();

        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //[Route("Lessons/{section}/{topic}/{subtopic}/{id:int}/Edit")]
        //public ActionResult Edit(int id)
        //{
        //    KillTheTest.Models.Objective o
        //        = new KillTheTest.Models.Objective();
        //    o.ObjectiveId = id;
        //    o.GetObjective();
        //    return View("Edit", o);
        //}


        //[HttpPost]
        //[Route("Lessons/{section}/{topic}/{subtopic}/{id:int}/Edit")]
        //public ActionResult Edit(Objective o)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Edit", o);
        //    }

        //    o.SaveObjective();

        //    return RedirectToAction( "Index","Lessons");
        //}

        //// GET: Objective/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Objective/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        
        //public string UserId
        //{
        //    get
        //    {
        //        if (User.Identity.Name != "")
        //        {
        //            return User.Identity.Name;
        //        }
        //        else
        //        {

        //            return Session.SessionID;
        //        }
        //    }
        //}
    }
}
