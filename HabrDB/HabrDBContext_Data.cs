using HabrDB.DBClasses;
using Microsoft.EntityFrameworkCore;

namespace HabrDB
{
	public partial class HabrDBContext:DbContext
	{
		public DbSet<Phone> Phones { get; set; }
	}
}
