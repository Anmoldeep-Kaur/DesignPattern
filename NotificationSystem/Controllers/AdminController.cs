using NotificationSystem.DTO.Models;
using NotificationSystem.DTO.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationSystem.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            EventService eventService = new EventService();
            var allEvents = eventService.GetEvents();
            return View(allEvents);
        }
        // GET: Admin/Add
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Event _event)
        {
            EventService eventService = new EventService();
            eventService.AddEvent(_event);
            TempData["notice"] = "Successfully registered";
            return RedirectToAction("Index");

        }
    }
}