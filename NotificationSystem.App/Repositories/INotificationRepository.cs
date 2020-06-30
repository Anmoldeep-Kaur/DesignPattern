using NotificationSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.App.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Events> GetEvents();
    }
}
