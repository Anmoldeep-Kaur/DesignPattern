namespace NotificationSystem.Data.Migrations
{
    using NotificationSystem.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NotificationSystem.Data.NotificationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NotificationSystem.Data.NotificationContext context)
        {
            var notificationTypes = new List<NotificationType>
            {
                new NotificationType{NotificationTypeId="Event"},
                new NotificationType{NotificationTypeId="Holiday"},
                new NotificationType{NotificationTypeId="NagarroNews"},
                new NotificationType{NotificationTypeId="NewPolicy"},
                new NotificationType{NotificationTypeId="UrgentHelp"},

            };
            notificationTypes.ForEach(c => context.Notifications.AddOrUpdate(c));
            context.SaveChanges();
        }
    }
}
