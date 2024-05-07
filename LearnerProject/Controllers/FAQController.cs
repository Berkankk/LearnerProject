using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class FAQController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var value = context.FAQs.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddFAQ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFAQ(FAQ FAQS)
        {
            context.FAQs.Add(FAQS);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public ActionResult DeleteFAQ(int id)
        {

            var values = context.FAQs.Find(id);
            context.FAQs.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        
        [HttpGet]
        public ActionResult UpdateFAQ(int id)
        {
            var values = context.FAQs.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateFAQ(FAQ FAQ)
        {
            var values = context.FAQs.Find(FAQ.FAQId);
            values.FAQId = FAQ.FAQId;
            values.Question = FAQ.Question;
            values.Answer = FAQ.Answer;
            values.ImageUrl = FAQ.ImageUrl;
            values.Status = FAQ.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}