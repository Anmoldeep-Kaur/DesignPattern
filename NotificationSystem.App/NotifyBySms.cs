﻿using NotificationSystem.Data;
using NotificationSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationSystem.App
{
    public class NotifyBySms : INotify
    {
        public void getMessage()
        {
            Console.WriteLine("From Sms");
        }

        public void sendNotification(string message, List<Employee> employee)
        {
            
            foreach(var emp in employee)
            {
                Console.WriteLine("Hi {0},{1}", emp.EmployeeName, message);
                
            }
        }
    }
}

