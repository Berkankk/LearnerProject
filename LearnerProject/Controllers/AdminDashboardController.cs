using LearnerProject.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminDashboardController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            

            ViewBag.v1 = context.Courses.Count();  //değerlerimizi turuyoruz
            ViewBag.v2 = context.Categories.Count();
            ViewBag.v3 = context.Classrooms.Count();
            ViewBag.v4 = context.Students.Count();
            ViewBag.v5 = context.Courses.OrderByDescending(x => x.Price).Select(x => x.CourseName).FirstOrDefault();  // fiyata göre sıralama yapıp ilk sıradakini getir dedik (OrderByDescending -> sıralama yüksekten küçüğe)
            ViewBag.v6 = context.Courses.Where(x => x.Category.CategoryName == "Kodlama").Count();  // kategori adı kodlama olan kursların sayısı
            ViewBag.v7 = context.Reviews.OrderByDescending(x => x.ReviewValue).Select(x => x.Course.CourseName).FirstOrDefault();  // en yükse puan almış kursun ismini getirir
            ViewBag.v8 = context.Courses.Where(x => x.Category.CategoryName == "Müzik").Count();
            ViewBag.v9 = context.Courses.Where(x => x.Category.CategoryName == "Spor").Count();
            // En çok yorum yapılan kursu bul
            var v10 = context.Reviews
                .GroupBy(r => r.CourseId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.FirstOrDefault().Course.CourseName)
                .FirstOrDefault();
            ViewBag.v10 = v10;

            // En çok kayıt yapılan kursu bul
            var v11 = context.CourseRegisters
                .GroupBy(c => c.CourseId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.FirstOrDefault().Course.CourseName)
                .FirstOrDefault();
            ViewBag.v11 = v11;

            return View();
        }
    }
}