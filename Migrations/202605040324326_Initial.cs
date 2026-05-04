namespace OOAD_Calendar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment",
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
                "dbo.Reminders",
                c => new
                    {
                        ReminderId = c.Int(nullable: false, identity: true),
                        ReminderTime = c.DateTime(nullable: false),
                        AppointmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReminderId)
                .ForeignKey("dbo.Appointment", t => t.AppointmentId, cascadeDelete: true)
                .Index(t => t.AppointmentId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.GroupMeetingParticipants",
                c => new
                    {
                        GroupMeetingId = c.Int(nullable: false),
                        CalendarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupMeetingId, t.CalendarId })
                .ForeignKey("dbo.GroupMeeting", t => t.GroupMeetingId, cascadeDelete: true)
                .ForeignKey("dbo.Calendars", t => t.CalendarId, cascadeDelete: true)
                .Index(t => t.GroupMeetingId)
                .Index(t => t.CalendarId);
            
            CreateTable(
                "dbo.GroupMeeting",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointment", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupMeeting", "Id", "dbo.Appointment");
            DropForeignKey("dbo.Appointment", "CalendarId", "dbo.Calendars");
            DropForeignKey("dbo.Calendars", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reminders", "AppointmentId", "dbo.Appointment");
            DropForeignKey("dbo.GroupMeetingParticipants", "CalendarId", "dbo.Calendars");
            DropForeignKey("dbo.GroupMeetingParticipants", "GroupMeetingId", "dbo.GroupMeeting");
            DropIndex("dbo.GroupMeeting", new[] { "Id" });
            DropIndex("dbo.GroupMeetingParticipants", new[] { "CalendarId" });
            DropIndex("dbo.GroupMeetingParticipants", new[] { "GroupMeetingId" });
            DropIndex("dbo.Reminders", new[] { "AppointmentId" });
            DropIndex("dbo.Calendars", new[] { "UserId" });
            DropIndex("dbo.Appointment", new[] { "CalendarId" });
            DropTable("dbo.GroupMeeting");
            DropTable("dbo.GroupMeetingParticipants");
            DropTable("dbo.Users");
            DropTable("dbo.Reminders");
            DropTable("dbo.Calendars");
            DropTable("dbo.Appointment");
        }
    }
}
