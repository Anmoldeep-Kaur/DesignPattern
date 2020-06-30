using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotificationSystem.Data.Entities
{
    public class EmployeeEventMap
    {
        [Key]
        public int EmployeeEventMapId { get; set; }
        public int EmployeeId { get; set; }
        public int EventId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee employee { get; set; }
        [ForeignKey("EventId")]
        public virtual Events events { get; set; }
    }
}
