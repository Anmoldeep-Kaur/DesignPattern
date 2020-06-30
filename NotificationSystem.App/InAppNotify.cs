using NotificationSystem.App;
using NotificationSystem.App.Domain;
using NotificationSystem.Data.Entities;
using System;
using System.Collections.Generic;

namespace Notificationsystem.App
{
    public class InAppNotify : INotify
    {
        public void getMessage()
        {
            Console.WriteLine("In App Notify");
        }

        public void sendNotification(string message, List<Employee> employee)
        {
            NotificationFinder notificationFinder = new NotificationFinder();
            
            
            foreach (var emp in employee)
            {
                Console.WriteLine("Hi {0}, {1}", emp.EmployeeName,message);
                
            }
        }
    }
}
