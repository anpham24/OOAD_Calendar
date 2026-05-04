using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD_Calendar.DTO
{
	[Table("GroupMeeting")]
	public class GroupMeeting : Appointment
	{
		public virtual ICollection<Calendar> Calendars { get; set; }
		public GroupMeeting()
		{
			Calendars = new HashSet<Calendar>();
		}

	}
}
