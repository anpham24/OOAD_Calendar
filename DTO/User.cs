using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD_Calendar.DTO
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		[Required]
		[StringLength(30)]
		public string UserName { get; set; }
		public virtual Calendar Calendar { get; set; }
	}
}
