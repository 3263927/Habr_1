using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabrDB
{
	public class ApplicationUser:IdentityUser
	{
		public String NickName { get; set; }
		public DateTime BirthDate { get; set; }
		public String PassportNumber { get; set; }
	}
}
