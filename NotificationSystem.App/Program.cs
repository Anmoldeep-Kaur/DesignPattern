using NotificationSystem.App.Domain;
using NotificationSystem.App.Factory;
using NotificationSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationSystem.App
{
    class Program
    {
        static void Main(string[] args)
        {
            NotificationFinder notificationFinder = new NotificationFinder();
            var notificationTypes = notificationFinder.FindAvailableEvents(DateTime.Now).GroupBy(e => e.NotificationTypeId);

            INotificationHandler notificationHandler;
            foreach (var group in notificationTypes)
            {
                List<Events> events = new List<Events>();
                Console.WriteLine(group.Key);
                foreach (var g in group)
                {

                    events.Add(g);

                }
                
                notificationHandler = NotificationHandlerFactory.GetHandler(group.Key);
                notificationHandler.create(events);
                
            }
            Console.ReadLine();
        }
    }
}
