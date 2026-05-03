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
        public string Message  { get; set; }

        [ForeignKey("Appoinment")]
        public int AppoinmentId { get; set; }
        public virtual Appointment Appoinment { get; set; }

    }
}
