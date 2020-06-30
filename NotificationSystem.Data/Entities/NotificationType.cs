using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotificationSystem.Data.Entities
{
    public class NotificationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string NotificationTypeId { get; set; }
    }
}
