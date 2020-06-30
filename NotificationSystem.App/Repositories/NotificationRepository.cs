using NotificationSystem.Data;
using NotificationSystem.Data.Concretes;
using NotificationSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationSystem.App.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        NotificationContext context = new NotificationContext();
        EventConcrete eventConcrete = new EventConcrete();
        public IEnumerable<Events> GetEvents()
        {
            var result = (from dbEvent in context.EventDetails
                          join dbSubscribedBy in context.SubscribedEvents
                          on dbEvent.NotificationTypeId equals dbSubscribedBy.NotificationTypeId
                          into dbEventSubscriptionTemp
                          from dbEventSubscription in dbEventSubscriptionTemp.DefaultIfEmpty()
                          select new
                          {
                             dbEvent,
                             dbEventSubscription

                          }).ToList();

            var eventList=result.Select(e=>e.dbEvent);
            return eventList.ToList();
        }


        public IEnumerable<EmployeeSubscribedEvent> GetEventsByMode()
        {
            var result = (from dbEvent in context.EventDetails
                          join dbSubscribedBy in context.SubscribedEvents
                          on dbEvent.NotificationTypeId equals dbSubscribedBy.NotificationTypeId
                          into dbEventSubscriptionTemp
                          from dbEventSubscription in dbEventSubscriptionTemp
                          where(dbEvent.EventDate.Year==DateTime.Now.Year
                          && dbEvent.EventDate.Month == DateTime.Now.Month
                          && dbEvent.EventDate.Day == DateTime.Now.Day)
                          select new 
                          {
                              dbEvent,
                              dbEventSubscription

                          }).ToList();
            var eventList = result.Select(e => e.dbEventSubscription);
            return eventList.ToList();
        }
        public void GetTodayEvents()
        {
            var result = (from dbEvent in context.EventDetails
                          join dbSubscribedBy in context.SubscribedEvents
                          on dbEvent.NotificationTypeId equals dbSubscribedBy.NotificationTypeId
                          into dbEventSubscriptionTemp
                          from dbEventSubscription in dbEventSubscriptionTemp
                          where (dbEvent.EventDate.Year == DateTime.Now.Year
                          && dbEvent.EventDate.Month == DateTime.Now.Month
                          && dbEvent.EventDate.Day == DateTime.Now.Day)
                          select new
                          {
                              dbEvent,
                              dbEventSubscription

                          }).ToList();
            var users = result.Select(e => e.dbEventSubscription).Distinct() ;
            var eventList = result.Where(e=>e.dbEventSubscription.NotifyInApp==true).Select(e => e.dbEvent).Distinct();

            foreach(var u in users)
            {
                foreach (var e in eventList)
                {
                    EmployeeEventMap employeeEventMap = new EmployeeEventMap()
                    {
                        
                        EmployeeId = u.EmployeeId,
                        EventId = e.EventId
                    };
                    eventConcrete.AddEventMap(employeeEventMap); 
                }
                
            }
        }



    }
}