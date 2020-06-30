namespace NotificationSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeEventMap",
                c => new
                    {
                        EmployeeEventMapId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeEventMapId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        EmployeeName = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        NotificationTypeId = c.String(maxLength: 128),
                        EventName = c.String(),
                        EventDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.NotificationType", t => t.NotificationTypeId)
                .Index(t => t.NotificationTypeId);
            
            CreateTable(
                "dbo.NotificationType",
                c => new
                    {
                        NotificationTypeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.NotificationTypeId);
            
            CreateTable(
                "dbo.EmployeeSubscribedEvent",
                c => new
                    {
                        EmployeeSubscribedEventId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        NotificationTypeId = c.String(maxLength: 128),
                        NoifyBySms = c.Boolean(nullable: false),
                        NotifyByEmail = c.Boolean(nullable: false),
                        NotifyInApp = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeSubscribedEventId)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.NotificationType", t => t.NotificationTypeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.NotificationTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeSubscribedEvent", "NotificationTypeId", "dbo.NotificationType");
            DropForeignKey("dbo.EmployeeSubscribedEvent", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.EmployeeEventMap", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "NotificationTypeId", "dbo.NotificationType");
            DropForeignKey("dbo.EmployeeEventMap", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.EmployeeSubscribedEvent", new[] { "NotificationTypeId" });
            DropIndex("dbo.EmployeeSubscribedEvent", new[] { "EmployeeId" });
            DropIndex("dbo.Events", new[] { "NotificationTypeId" });
            DropIndex("dbo.EmployeeEventMap", new[] { "EventId" });
            DropIndex("dbo.EmployeeEventMap", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeSubscribedEvent");
            DropTable("dbo.NotificationType");
            DropTable("dbo.Events");
            DropTable("dbo.Employee");
            DropTable("dbo.EmployeeEventMap");
        }
    }
}
