using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.DTO.Models
{
    public class Events
    {
        public int ID { get; set; }
        public string NotificationType { get; set; }
        public bool Subscribe { get; set; }
    }
}
