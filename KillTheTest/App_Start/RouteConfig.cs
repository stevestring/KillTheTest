using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KillTheTest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "StudentLesson",
               url: "Lessons/Lesson/{section}/{topic}/{subtopic}/{objective}/{url}",
               defaults: new { controller = "Lessons", action = "StudentLesson", url = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "LessonComplete",
               url: "Lessons/Lesson/UserComplete/{id}",
               defaults: new { controller = "Lessons", action = "LessonComplete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "TeacherLesson",
               url: "Lessons/Lesson/{section}/{topic}/{subtopic}/{objective}/{url}/Teacher",
               defaults: new { controller = "Lessons", action = "TeacherLesson", url = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "LessonEdit",
               url: "Lessons/Lesson/{section}/{topic}/{subtopic}/{objective}/{url}/{id}",
               defaults: new { controller = "Lessons", action = "StudentLesson", url = UrlParameter.Optional,id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "ObjectiveDetails",
               url: "Lessons/Objective/{section}/{unit}/{subtopic}/{id}",
               defaults: new { controller = "Lessons", action = "ObjectiveDetails", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "ObjectiveHandout",
               url: "Lessons/Objective/{section}/{unit}/{subtopic}/{id}/Handout",
               defaults: new { controller = "Lessons", action = "ObjectiveHandout", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "ObjectiveComplete",
               url: "Lessons/Objective/{id}/Complete",
               defaults: new { controller = "Lessons", action = "ObjectiveComplete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Section",
               url: "Lessons/Section/{url}",
               defaults: new { controller = "Lessons", action = "SectionDetails", url = UrlParameter.Optional }
            );


            ///These should go away if the above works.
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
