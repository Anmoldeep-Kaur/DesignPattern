using Notificationsystem.App;
using NotificationSystem.Data.Entities;
using System.Collections.Generic;

namespace NotificationSystem.App
{
    public class NotificationManager
    {
        INotify notify;
        private InAppNotify inAppNotify;

        public NotificationManager(INotify iNotify)
        {
            this.notify = iNotify;
        }

        //public NotificationManager(InAppNotify inAppNotify)
        //{
          //  this.inAppNotify = inAppNotify;
        //}

        public void NotificationInterface(string msg,List<Employee> employee)
        {
            this.notify.getMessage();
            this.notify.sendNotification(msg,employee);
        }
    }
}
