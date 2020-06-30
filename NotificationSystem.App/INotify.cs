using NotificationSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.App
{
    public interface INotify
    {
        void getMessage();
        void sendNotification(string msg,List<Employee> employee);
    }
}
