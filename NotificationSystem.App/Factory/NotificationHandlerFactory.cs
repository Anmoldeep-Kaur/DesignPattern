using NotificationSystem.App.Concretes;
using System;

namespace NotificationSystem.App.Factory
{
    public class NotificationHandlerFactory 
    {
        public static INotificationHandler GetHandler(string notificationType)
        {
            if (notificationType == null)
            {
                return null;
            }
            if (notificationType.Equals("event", StringComparison.InvariantCultureIgnoreCase))
            {
                return new EventNotificationHandler();

            }
            else if (notificationType.Equals("UrgentHelp", StringComparison.InvariantCultureIgnoreCase))
            {
                return new UrgentNotificationHandler();

            }
            else if (notificationType.Equals("NewPolicy", StringComparison.InvariantCultureIgnoreCase))
            {
                return new PolicyNotificationHandler();
            }
            else if (notificationType.Equals("holiday", StringComparison.InvariantCultureIgnoreCase))
            {
                return new HolidayNotificationHandler();
            }
            else if (notificationType.Equals("NagarroNews", StringComparison.InvariantCultureIgnoreCase))
            {
                return new NewsNotificationHandler();
            }

            return null;
        }
    }
}
