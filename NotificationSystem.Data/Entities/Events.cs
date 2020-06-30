using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Data.Entities
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        public string NotificationTypeId { get; set; }
        [ForeignKey("NotificationTypeId")]
        public virtual NotificationType notification { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
    }
}
