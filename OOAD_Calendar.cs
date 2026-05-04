using OOAD_Calendar.DTO;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace OOAD_Calendar
{
	public class OOAD_Calendar : DbContext
	{
		// Your context has been configured to use a 'OOAD_Calendar' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'OOAD_Calendar.OOAD_Calendar' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'OOAD_Calendar' 
		// connection string in the application configuration file.
		public OOAD_Calendar()
			: base("name=OOAD_Calendar")
		{
		}

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Calendar> Calendars { get; set; }
		public virtual DbSet<Appointment> Appointments { get; set; }
		public virtual DbSet<GroupMeeting> GroupMeetings { get; set; }
		public virtual DbSet<Reminder> Reminders { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<GroupMeeting>()
				// 1. Chỉ định 1 GroupMeeting có nhiều ParticipantCalendars
				.HasMany(g => g.Calendars)
				// 2. Chỉ định chiều ngược lại: 1 Calendar tham gia nhiều JoinedGroupMeetings
				.WithMany(c => c.GroupMeetings)
				// 3. Cấu hình bảng trung gian (Junction Table)
				.Map(m =>
				{
					// Đặt tên cho bảng trung gian trong SQL Server
					m.ToTable("GroupMeetingParticipants");

					// Cột khóa ngoại trỏ về Id của GroupMeeting
					m.MapLeftKey("GroupMeetingId");

					// Cột khóa ngoại trỏ về UserId của Calendars
					m.MapRightKey("CalendarId");
				});
		}

		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		// public virtual DbSet<MyEntity> MyEntities { get; set; }
	}

	//public class MyEntity
	//{
	//    public int Id { get; set; }
	//    public string Name { get; set; }
	//}
}