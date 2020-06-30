using NotificationSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Data.Concretes
{
    public class EventConcrete
    {
        NotificationContext context = new NotificationContext();

        public IEnumerable<Events> GetEvents()
        {
            return context.EventDetails.ToList();
        }

        public int  AddEvent(Events events)
        {
            
            context.EventDetails.Add(events);
            return context.SaveChanges();
            
        }
        public int AddEventMap(EmployeeEventMap employeeEventMap)
        {
            context.employeeEvents.Add(employeeEventMap);
            return context.SaveChanges();
        }

    }
}
