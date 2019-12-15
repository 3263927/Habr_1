using HabrDB;
using HabrDB.DBClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Extensions;

namespace DBTest
{
	[TestClass]
	public class DBTest:DBTestBase
	{
		[TestMethod]
		public async Task AddPhone_Test()
		{
			String PhoneName = "Nokia";
			DateTime now = DateTime.Now;

			List<Phone> Phones = await db.GetAllPhones();
			Assert.AreEqual(0, Phones.Count);

			Phone ph = new Phone();
			ph.Model = PhoneName;
			ph.DayZero = now;

			await db.AddPhone(ph);

			Phone ph1 = db.Phones.Single();
			Assert.AreEqual(PhoneName, ph1.Model);
			Assert.AreEqual(now, ph1.DayZero);
		}

		[ClassCleanup]
		public static void DeleteTable()
		{
			db.Database.EnsureDeleted(db.Phones);
		}
	}
}
