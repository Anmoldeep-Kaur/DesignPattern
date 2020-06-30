using System;
using System.ComponentModel.DataAnnotations;

namespace NotificationSystem.DTO.Models
{
    public class Event
    {
        [Display(Name ="Event Name")]
        public string EventName { get; set; }
        [Display(Name ="Event Date")]
        public DateTime EventDate { get; set; }
        public string NotificationType { get; set; }
        public NotificationType notification { get; set; }
        
    }

    public enum NotificationType
    {
        Event,
        UrgentHelp,
        Holiday,
        NagarroNews,
        NewPolicy
    }
}
