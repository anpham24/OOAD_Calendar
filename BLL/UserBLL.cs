using OOAD_Calendar.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD_Calendar.BLL
{
	public class UserBLL
	{
		public User Login(string username) {
			if (string.IsNullOrWhiteSpace(username)) {
				return null;
			}
			using (var db = new OOAD_Calendar())
			{
				var user = db.Users.FirstOrDefault(u => u.UserName == username.Trim());

				return user;
			}
		}
		public bool Register(string username)
		{
			if (string.IsNullOrWhiteSpace(username))
			{
				return false;
			}

			using (var db = new OOAD_Calendar())
			{
				string cleanUsername = username.Trim();

				bool isExist = db.Users.Any(u => u.UserName == cleanUsername);
				if (isExist)
				{
					return false;
				}

				User newUser = new User
				{
					UserName = cleanUsername
				};

				db.Users.Add(newUser);
				db.SaveChanges(); 

				Calendar newCalendar = new Calendar
				{
					UserId = newUser.UserId
				};

				db.Calendars.Add(newCalendar);
				db.SaveChanges(); 

				return true; 
			}
		}
		public List<User> GetOtherUsers(int currentUserId)
		{
			using (var db = new OOAD_Calendar()) 
			{
				var otherUsers = db.Users
								   .Where(u => u.UserId != currentUserId)
								   .ToList();

				return otherUsers;
			}
		}
	}
}
