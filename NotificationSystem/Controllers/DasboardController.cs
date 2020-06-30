using NotificationSystem.Data;
using NotificationSystem.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationSystem.Controllers
{
    public class DasboardController : Controller
    {
        // GET: Dasboard
        public ActionResult Index()
        {
            var currentUser = Session["EmployeeId"].ToString(); 
            NotificationContext notificationContext = new NotificationContext();
            List<Event> events1 = new List<Event>();
            var eventsList = notificationContext.employeeEvents.Where(e =>e.EmployeeId.ToString().Equals(currentUser)).Select(e => e.EventId).ToList().Distinct();
            foreach(var ev in eventsList)
            {
                var events = notificationContext.EventDetails.Where(e => e.EventId == ev).Select(e => e).Distinct();
                foreach(var e in events)
                {
                    Event _event = new Event()
                    {
                        EventName = e.EventName,
                        EventDate = e.EventDate
                    };
                    events1.Add(_event);
                }
            }
            return View(events1);
            
        }
    }
}