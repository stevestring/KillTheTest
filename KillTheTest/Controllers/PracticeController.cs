using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KillTheTest.Controllers
{
    public class PracticeController : Controller
    {
        // GET: Practice
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Practice(string url)
        public ActionResult Practice()
        {
            string url = "test";

            KillTheTest.Models.Practice practice
                = new KillTheTest.Models.Practice();
            practice.PracticeUrl = url;
            practice.GetPracticeByUrl();
            //practice.GetPracticesInObjective(UserId);
            return View("PracticeDetails", practice);
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