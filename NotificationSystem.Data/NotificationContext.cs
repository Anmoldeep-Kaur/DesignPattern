using NotificationSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Data
{
    public class NotificationContext:DbContext
    {
        public NotificationContext() : base("NotificationSystem")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<NotificationType> Notifications { get; set; }
        public DbSet<EmployeeSubscribedEvent> SubscribedEvents { get; set; }
        public DbSet<Events> EventDetails { get; set; }
        public DbSet<EmployeeEventMap> employeeEvents { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
