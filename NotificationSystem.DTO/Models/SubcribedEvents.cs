namespace NotificationSystem.DTO.Models
{
    public class SubcribedEvents
    {
        public int EmployeeId { get; set; }
        public string NotificationTypeId { get; set; }
        
        public bool NoifyBySms { get; set; }
        public bool NotifyByEmail { get; set; }
        public bool NotifyInApp { get; set; }
    }
}
