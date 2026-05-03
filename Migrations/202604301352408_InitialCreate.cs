namespace OOAD_Calendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Location = c.String(),
                        CalendarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Calendars", t => t.CalendarId, cascadeDelete: true)
                .Index(t => t.CalendarId);
            
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 30),
                        GroupMeeting_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.GroupMeeting", t => t.GroupMeeting_Id)
                .Index(t => t.GroupMeeting_Id);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        ReminderId = c.Int(nullable: false, identity: true),
                        ReminderTime = c.DateTime(nullable: false),
                        Message = c.String(),
                        AppoinmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReminderId)
                .ForeignKey("dbo.Appointments", t => t.AppoinmentId, cascadeDelete: true)
                .Index(t => t.AppoinmentId);
            
            CreateTable(
                "dbo.GroupMeeting",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupMeeting", "Id", "dbo.Appointments");
            DropForeignKey("dbo.Users", "GroupMeeting_Id", "dbo.GroupMeeting");
            DropForeignKey("dbo.Reminders", "AppoinmentId", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "CalendarId", "dbo.Calendars");
            DropForeignKey("dbo.Calendars", "UserId", "dbo.Users");
            DropIndex("dbo.GroupMeeting", new[] { "Id" });
            DropIndex("dbo.Reminders", new[] { "AppoinmentId" });
            DropIndex("dbo.Users", new[] { "GroupMeeting_Id" });
            DropIndex("dbo.Calendars", new[] { "UserId" });
            DropIndex("dbo.Appointments", new[] { "CalendarId" });
            DropTable("dbo.GroupMeeting");
            DropTable("dbo.Reminders");
            DropTable("dbo.Users");
            DropTable("dbo.Calendars");
            DropTable("dbo.Appointments");
        }
    }
}
