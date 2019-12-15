using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HabrDB
{
	public class SecurityDBContext : IdentityDbContext<ApplicationUser>
	{
		public SecurityDBContext(DbContextOptions<SecurityDBContext> options)
			: base(options)
		{
		}
	}
}
