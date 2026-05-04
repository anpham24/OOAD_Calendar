using OOAD_Calendar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD_Calendar.BLL
{
	public class EventBLL
	{
		public List<DateTime> GetDatesWithEvents(int calendarId, int month, int year)
		{
			using (var db = new OOAD_Calendar())
			{
				var myEventDates = db.Appointments
					.Where(a => a.CalendarId == calendarId
							 && a.StartTime.Year == year
							 && a.StartTime.Month == month)
					.Select(a => a.StartTime);

				var invitedEventDates = db.GroupMeetings
					.Where(gm => gm.Calendars.Any(c => c.UserId == calendarId) // Kiểm tra xem user có trong danh sách tham gia không
							  && gm.StartTime.Year == year
							  && gm.StartTime.Month == month)
					.Select(gm => gm.StartTime);

				var eventDates = myEventDates.Union(invitedEventDates)
					.ToList()
					.Select(d => d.Date)
					.Distinct()
					.ToList();

				return eventDates;
			}
		}
		public List<dynamic> GetEventsByDate(int calendarId, DateTime selectedDate)
		{
			using (var db = new OOAD_Calendar())
			{
				var myEvents = db.Appointments
					.Where(a => a.CalendarId == calendarId
							 && a.StartTime.Year == selectedDate.Year
							 && a.StartTime.Month == selectedDate.Month
							 && a.StartTime.Day == selectedDate.Day)
					.ToList(); 

				var invitedEvents = db.GroupMeetings
					.Where(gm => gm.Calendars.Any(c => c.UserId == calendarId)
							  && gm.StartTime.Year == selectedDate.Year
							  && gm.StartTime.Month == selectedDate.Month
							  && gm.StartTime.Day == selectedDate.Day)
					.ToList() 
					.Cast<Appointment>(); 

				var combined = myEvents.Union(invitedEvents)
					.OrderBy(e => e.StartTime)
					.Select(e => new
					{
						Name = e.Name,
						StartTime = e.StartTime.ToString("HH:mm"),
						EndTime = e.EndTime.ToString("HH:mm"),
						Location = e.Location,
						Type = (e is GroupMeeting) ? "Họp nhóm" : "Cá nhân"
					}).ToList<dynamic>();

				return combined;
			}
		}
		public bool ValidateTime(DateTime start, DateTime end)
		{
			return start < end;
		}
		public bool HasOverlappingEvents(int calendarId, DateTime start, DateTime end, int? excludeEventId = null)
		{
			using (var db = new OOAD_Calendar())
			{
				bool isOverlapWithMyEvents = db.Appointments.Any(a =>
					a.CalendarId == calendarId &&
					a.Id != excludeEventId &&
					start < a.EndTime &&
					end > a.StartTime
				);

				if (isOverlapWithMyEvents) return true;

				bool isOverlapWithInvitedEvents = db.GroupMeetings.Any(gm =>
					gm.Calendars.Any(c => c.UserId == calendarId) &&
					gm.Id != excludeEventId &&
					start < gm.EndTime &&
					end > gm.StartTime
				);

				return isOverlapWithInvitedEvents;
			}
		}
		public GroupMeeting FindMatchingGroupMeeting(string name, TimeSpan duration, DateTime start, DateTime end)
		{
			using (var db = new OOAD_Calendar())
			{
				var matchingMeeting = db.GroupMeetings.FirstOrDefault(gm =>
					gm.Name == name &&
					gm.StartTime == start &&
					gm.EndTime == end
				);

				return matchingMeeting;
			}
		}
		public void CreateAppointment(Appointment appt, List<DateTime> reminderTimes)
		{
			using (var db = new OOAD_Calendar())
			{
				db.Appointments.Add(appt);
				db.SaveChanges();

				if (reminderTimes != null && reminderTimes.Any())
				{
					foreach (DateTime time in reminderTimes)
					{
						var reminder = new Reminder
						{
							ReminderTime = time,
							AppointmentId = appt.Id 
						};

						db.Reminders.Add(reminder);
					}

					db.SaveChanges();
				}
			}
		}
		public void CreateGroupMeeting(GroupMeeting meeting, List<DateTime> reminderTimes, List<int> participantCalendarIds)
		{
			using (var db = new OOAD_Calendar())
			{
				if (meeting.Calendars == null)
					meeting.Calendars = new List<Calendar>();

				if (!participantCalendarIds.Contains(meeting.CalendarId))
					participantCalendarIds.Add(meeting.CalendarId);

				var participants = db.Calendars
									 .Where(c => participantCalendarIds.Contains(c.UserId))
									 .ToList();

				foreach (var p in participants)
				{
					meeting.Calendars.Add(p);
				}

				db.GroupMeetings.Add(meeting);
				db.SaveChanges();

				if (reminderTimes != null && reminderTimes.Any())
				{
					foreach (DateTime time in reminderTimes)
					{
						var reminder = new Reminder
						{
							ReminderTime = time,
							AppointmentId = meeting.Id
						};
						db.Reminders.Add(reminder);
					}

					db.SaveChanges();
				}
			}
		}
		public void JoinGroupMeeting(int calendarId, int groupMeetingId)
		{
			using (var db = new OOAD_Calendar())
			{
				var meeting = db.GroupMeetings.FirstOrDefault(g => g.Id == groupMeetingId);
				var userCalendar = db.Calendars.FirstOrDefault(c => c.UserId == calendarId);

				if (meeting != null && userCalendar != null)
				{
					bool isAlreadyJoined = meeting.Calendars != null && meeting.Calendars.Any(c => c.UserId == calendarId);

					if (!isAlreadyJoined)
					{
						if (meeting.Calendars == null)
							meeting.Calendars = new List<Calendar>();

						meeting.Calendars.Add(userCalendar);
						db.SaveChanges();
					}
				}
				else
				{
					throw new Exception("Không tìm thấy cuộc họp hoặc lịch của người dùng.");
				}
			}
		}
		// Hàm xóa các sự kiện bị trùng thời gian (Dùng cho tính năng "Thay thế/Replace")
		public void DeleteOverlappingEvents(int calendarId, DateTime start, DateTime end)
		{
			using (var db = new OOAD_Calendar())
			{
				var overlappedAppointments = db.Appointments.Where(a =>
					a.CalendarId == calendarId &&
					start < a.EndTime &&
					end > a.StartTime
				).ToList();

				if (overlappedAppointments.Any())
				{
					db.Appointments.RemoveRange(overlappedAppointments);
				}

				var overlappedGroupMeetings = db.GroupMeetings.Where(gm =>
					gm.Calendars.Any(c => c.UserId == calendarId) &&
					start < gm.EndTime &&
					end > gm.StartTime
				).ToList();

				var userCalendar = db.Calendars.FirstOrDefault(c => c.UserId == calendarId);
				if (userCalendar != null)
				{
					foreach (var meeting in overlappedGroupMeetings)
					{
						meeting.Calendars.Remove(userCalendar);
					}
				}

				db.SaveChanges();
			}
		}
	}
}
