using NotificationSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.App.Factory
{
    public interface INotificationHandler
    {
        void create(List<Events> events);
        void send();
        void clear();
        void handle(string msg ,Events _events );
    }
}
