using NotificationSystem.App.Repositories;
using NotificationSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationSystem.App.Domain
{
    public class NotificationFinder
    {

        NotificationRepository _repository = new NotificationRepository();
        public List<Events> FindAvailableEvents(DateTime currentTime)
        {
            _repository.GetTodayEvents();
            
            var availableEvents = _repository.GetEvents()
                                 .Where(e => e.EventDate.Year == currentTime.Year
                                 && e.EventDate.Month == currentTime.Month
                                 && e.EventDate.Day == currentTime.Day).Distinct();
            
            return availableEvents.ToList();

        }
        
       
        public List<EmployeeSubscribedEvent> FindAvailableEventsByMode()
        {

            var availableEvents = _repository.GetEventsByMode();
            return availableEvents.ToList();

        }

    }
}
