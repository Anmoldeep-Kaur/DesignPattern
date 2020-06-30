using Notificationsystem.App;
using NotificationSystem.App.Domain;
using NotificationSystem.App.Factory;
using NotificationSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationSystem.App.Concretes
{
    public class UrgentNotificationHandler : INotificationHandler
    {
        private const string MessageTemplate =
            "There is an urgent need for {0}\n" +
            "Posted on:{1}";
        private const string SmsMessageTemplate =
            "{0} on {1}";

        public void clear()
        {
            throw new NotImplementedException();
        }

        public void create(List<Events> events)
        {

            foreach (var e in events)
            {
                string notificationMsg = string.Format(MessageTemplate,  e.EventName, e.EventDate.Date);
                handle(notificationMsg,e);
            }


        }
        public void handle(string message,Events events)
        {
            NotificationFinder notificationFinder = new NotificationFinder();
            var eventsSms = notificationFinder.FindAvailableEventsByMode()
                            .Where(e => e.NoifyBySms == true && e.NotificationTypeId == events.NotificationTypeId).Select(e => e.employee).Distinct().ToList();
            var eventsEmail = notificationFinder.FindAvailableEventsByMode()
                            .Where(e => e.NotifyByEmail == true && e.NotificationTypeId == events.NotificationTypeId).Select(e => e.employee).Distinct().ToList();
            var eventsInApp = notificationFinder.FindAvailableEventsByMode()
                            .Where(e => e.NotifyInApp == true && e.NotificationTypeId == events.NotificationTypeId).Select(e => e.employee).Distinct().ToList();

            NotificationManager notificationManager;

            if (eventsSms.Count>0)
            {
                notificationManager = new NotificationManager(new NotifyBySms());
                notificationManager.NotificationInterface(message, eventsSms);
            }
            Console.WriteLine("-------------------------");

            if (eventsEmail.Count>0)
            {
                notificationManager = new NotificationManager(new NotifyByEmail());
                notificationManager.NotificationInterface(message, eventsEmail);
            }
            Console.WriteLine("-------------------------");
            if (eventsInApp.Count>0)
            {
                notificationManager = new NotificationManager(new InAppNotify());
                notificationManager.NotificationInterface(message, eventsInApp);
            }
            

        }

        public void send()
        {
            throw new NotImplementedException();
        }
    }
}
