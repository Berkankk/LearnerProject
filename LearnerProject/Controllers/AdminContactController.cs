using LearnerProject.Models.Context;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class AdminContactController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var value = context.Contacts.ToList();
            return View(value);
        }
        public ActionResult DeleteContact(int id)
        {
            var sil = context.Contacts.Find(id);
            context.Contacts.Remove(sil);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var güncelle = context.Contacts.Find(id);
            return View(güncelle);
        }
        [HttpPost]
        public ActionResult UpdateContact(Contact contact)
        {
            var güncelle = context.Contacts.Find(contact.ContactId);
            güncelle.Address = contact.Address;
            güncelle.Phone = contact.Phone;
            güncelle.Email = contact.Email;
            güncelle.OpenHours = contact.OpenHours;
            context.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}