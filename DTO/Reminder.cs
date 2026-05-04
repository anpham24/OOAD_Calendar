using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD_Calendar.DTO
{
	public class Reminder
	{
		[Key]
		public int ReminderId { get; set; }
		[Required]
		public DateTime ReminderTime { get; set; }

		[ForeignKey("Appointment")]
		public int AppointmentId { get; set; }
		public virtual Appointment Appointment { get; set; }

	}
}
