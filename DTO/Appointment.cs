using OOAD_Calendar.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOAD_Calendar
{
	[Table("Appointment")]
	public class Appointment
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public DateTime StartTime { get; set; }
		[Required]
		public DateTime EndTime { get; set; }
		public String Location { get; set; }

		[ForeignKey("Calendar")]
		public int CalendarId { get; set; }
		public virtual Calendar Calendar { get; set; }
		public virtual ICollection<Reminder> Reminders { get; set; }
		public Appointment()
		{
			Reminders = new HashSet<Reminder>();
		}
	}
}
