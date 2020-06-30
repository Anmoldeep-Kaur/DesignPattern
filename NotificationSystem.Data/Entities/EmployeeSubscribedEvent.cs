using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Data.Entities
{
    public class EmployeeSubscribedEvent
    {
        public int EmployeeSubscribedEventId { get; set; }
        public int EmployeeId { get; set; }
        public string NotificationTypeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee employee { get; set; }
        [ForeignKey("NotificationTypeId")]
        public virtual  NotificationType notification { get; set; }
        public bool NoifyBySms { get; set; }
        public bool NotifyByEmail { get; set; }
        public bool NotifyInApp { get; set; }
    }
}
