using NotificationSystem.DTO.Models;
using NotificationSystem.DTO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationSystem.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        // GET: Registration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registration/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Registration/Create
        [HttpPost]
        public ActionResult Register(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            RegistrationService registrationService = new RegistrationService();
            try
            {
                registrationService.AddUser(employee);
                ViewBag.Message = "Registration Successful";
              

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        // GET: Registration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registration/Delete/5
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
    }
}
