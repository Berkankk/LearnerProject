using LearnerProject.Models;
using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class DefaultController : Controller
    {
        LearnerContext context = new LearnerContext();
        
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultCoursePartial()
        {
            
            var values = context.Courses.Include(x=>x.Reviews).OrderByDescending(x=>x.CourseId).Take(3).ToList();
            return PartialView(values);
        }
        public ActionResult CourseDetail(int id)
        {
            var values = context.Courses.Find(id);
            var reviewList = context.Reviews.Where(x=>x.CourseId== id).ToList();
            ViewBag.review = reviewList;
            return View(values);
        }
        public PartialViewResult DefaultCategoryPartiaal()
        {
            ViewBag.v1 = context.Courses.Where(x => x.Category.CategoryName == "Kodlama").Count();  // kategori adı kodlama olan kursların sayısı


            var values = context.Categories.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTestimonialPartial()
        {
            var value = context.Testimonials.ToList();
            return PartialView(value);
        }
        public PartialViewResult DefaultClassroomPartial()
        {
            var values = context.Classrooms.OrderByDescending(x => x.ClassroomId).Take(6).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTeacherPartial()
        {
            var values = context.Teachers.OrderByDescending(x => x.TeacherId).Take(6).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultFAQPartial()
        {
           
            var values = context.FAQs.Where(x=>x.Status==true).OrderByDescending(x=>x.FAQId).Take(6).ToList();

            return PartialView(values);
        }
        public PartialViewResult DefaultAboutPartial()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
    }
}