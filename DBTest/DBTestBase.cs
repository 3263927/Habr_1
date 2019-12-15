using HabrDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace DBTest
{
	[TestClass]
	public class DBTestBase
	{
		public static HabrDBContext db{ get; set; }

		/// <summary>
		/// Executes once before the test run. (Optional)
		/// </summary>
		/// <param name="context"></param>
		[AssemblyInitialize]
		public static void AssemblyInit(TestContext context)
		{
			db = new HabrDBContext().CreateTestContext();
			db.Database.EnsureCreated();
		}
		/// <summary>
		/// Executes before this class creation
		/// </summary>
		/// <param name="context"></param>
		[ClassInitialize]
		public static void TestFixtureSetup(TestContext context)
		{

		}

		/// <summary>
		/// Executes Before each test 
		/// </summary>
		[TestInitialize]
		public void Setup()
		{

		}

		/// <summary>
		/// Executes once after the test run
		/// </summary>
		[AssemblyCleanup]
		public static void AssemblyCleanup()
		{

		}

		/// <summary>
		/// Runs once after all tests in this class are executed.
		/// Not guaranteed that it executes instantly after all tests from the class.
		/// </summary>
		[ClassCleanup]
		public static void TestFixtureTearDown()
		{

		}

		/// <summary>
		/// Executes after each test
		/// </summary>
		[TestCleanup]
		public void TearDown()
		{
			//db.Database.EnsureDeleted();//don`t call! delete database instead of tables!
		}
	}
}
