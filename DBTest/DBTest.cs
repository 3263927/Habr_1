using HabrDB;
using HabrDB.DBClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBTest
{
	[TestClass]
	public class DBTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			String PhoneName = "Nokia";
			DateTime now = DateTime.Now;

			HabrDBContext db = new HabrDBContext().CreateTestContext();
			db.Database.EnsureCreated();

			List<Phone> Phones = db.Phones.ToList();
			Assert.AreEqual(0, Phones.Count);

			Phone ph = new Phone();
			ph.Model = PhoneName;
			ph.DayZero = now;

			db.Phones.Add(ph);
			db.SaveChanges();

			Phone ph1 = db.Phones.Single();
			Assert.AreEqual(PhoneName, ph1.Model);
			Assert.AreEqual(now, ph1.DayZero);
		}
	}
}
