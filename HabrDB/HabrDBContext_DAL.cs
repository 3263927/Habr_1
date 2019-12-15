using HabrDB.DBClasses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabrDB
{
	public partial class HabrDBContext:DbContext
	{
		public async Task<int> AddPhone(Phone ph)
		{
			this.Phones.Add(ph);
			int res = await this.SaveChangesAsync();
			return res;
		}

		public async Task<List<Phone>> GetAllPhones()
		{
			List<Phone> phones = await this.Phones.ToListAsync();
			return phones;
		}
	}
}
