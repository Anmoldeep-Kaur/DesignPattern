using NotificationSystem.Data;
using NotificationSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NotificationSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Event()
        {
            NotificationContext context = new NotificationContext();
            var events = context.Notifications.ToList();
            var eventList = events.Select(e => e);
            List<DTO.Models.Events> events2 = new List<DTO.Models.Events>();
            foreach (var e in eventList)
            {
                DTO.Models.Events events1 = new DTO.Models.Events()
                {
                    NotificationType = e.NotificationTypeId
                };
                events2.Add(events1);
            }
            return View(events2);
        }
       
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Event(IEnumerable<DTO.Models.Events> events)
        {
            NotificationContext context = new NotificationContext();
            var currentUser= Session["EmployeeId"]?.ToString();
            var UserId = Convert.ToInt32(currentUser);
            foreach (var e in events)
            {
                if (e.Subscribe)
                {
                    EmployeeSubscribedEvent employeeSubscribedEvent = new EmployeeSubscribedEvent()
                    {
                        EmployeeId = Convert.ToInt32(currentUser),
                        NotificationTypeId = e.NotificationType
                    };
                    context.SubscribedEvents.Add(employeeSubscribedEvent);
                    context.SaveChanges();
                    if (e.NotificationType.Equals("Celebration"))
                    {
                        var CelebrationEvents = context.SubscribedEvents.Where(x => x.NotificationTypeId == e.NotificationType
                                                                                  && x.EmployeeId == UserId);

                        foreach (var ce in CelebrationEvents)
                        {
                            ce.NotifyByEmail = true;
                            ce.NotifyInApp = true;
                        }
                    }
                    else if (e.NotificationType.Equals("Event"))
                    {
                        var Events = context.SubscribedEvents.Where(x => x.NotificationTypeId == e.NotificationType && 
                                                                    x.EmployeeId == UserId)
                                              .Select(x => x);
                        foreach (var ce in Events)
                        {
                            ce.NotifyByEmail = true;
                            ce.NotifyInApp = true;
                        }
                    }

                    else if (e.NotificationType.Equals("UrgentHelp"))
                    {
                        var HelpEvents = context.SubscribedEvents.Where(x => x.NotificationTypeId == e.NotificationType
                                                                        && x.EmployeeId == UserId)
                                              .Select(x => x);
                        foreach (var ce in HelpEvents)
                        {
                            ce.NotifyByEmail = true;
                            ce.NoifyBySms = true;
                        }

                    }
                    else if (e.NotificationType.Equals("NagarroNews"))
                    {
                        var NewsEvents = context.SubscribedEvents.Where(x => x.NotificationTypeId == e.NotificationType &&
                                         x.EmployeeId == UserId)
                                              .Select(x => x);
                        foreach (var ce in NewsEvents)
                        {
                            ce.NotifyByEmail = true;
                            ce.NotifyInApp = true;
                        }

                    }
                    else if (e.NotificationType.Equals("Holiday"))
                    {
                        var Holidays = context.SubscribedEvents.Where(x => x.NotificationTypeId == e.NotificationType 
                                                                      && x.EmployeeId == UserId)
                                              .Select(x => x);
                        foreach (var ce in Holidays)
                        {

                            ce.NotifyInApp = true;
                        }

                    }
                    else if (e.NotificationType.Equals("NewPolicy"))
                    {
                        var PolicyEvents = context.SubscribedEvents.Where(x => x.NotificationTypeId == e.NotificationType 
                                                                          && x.EmployeeId == UserId)
                                              .Select(x => x);
                        foreach (var ce in PolicyEvents)
                        {
                            ce.NotifyByEmail = true;
                            ce.NotifyInApp = true;
                        }

                    }
                    context.SaveChanges();
                }
                
            }

            return RedirectToAction("Index", "Dasboard");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}