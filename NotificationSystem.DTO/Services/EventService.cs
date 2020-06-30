using NotificationSystem.Data.Concretes;
using NotificationSystem.DTO.Models;
using System.Collections.Generic;

namespace NotificationSystem.DTO.Services
{
    public class EventService
    {
        EventConcrete eventConcrete = new EventConcrete();

        public IEnumerable<Event> GetEvents()
        {
            List<Event> eventList = new List<Event>();
            var allEvents=eventConcrete.GetEvents();
            foreach(var ev in allEvents)
            {
                Event _event = new Event()
                { 
                    EventName=ev.EventName,
                    EventDate=ev.EventDate,
                    NotificationType=ev.NotificationTypeId
                };
                eventList.Add(_event);
            }
            return eventList;
        }
        public void AddEvent(Event _event)
        {
            Data.Entities.Events events = new Data.Entities.Events()
            {
                EventName = _event.EventName,
                EventDate = _event.EventDate,
                NotificationTypeId = _event.NotificationType
            };

            eventConcrete.AddEvent(events);
        }
       
    }
}
