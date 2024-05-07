using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AllCourseController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            ViewBag.v1 = context.Courses.Count();
            return View();
        }
        public PartialViewResult CourseInfo()
        {
            ViewBag.v1 = context.Courses.Count();
           
            var value = context.Courses.ToList();

            
            return PartialView(value);
        }
    }
}