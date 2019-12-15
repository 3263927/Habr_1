using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HabrDB
{
	public partial class HabrDBContext:DbContext
	{
		public String ConnectionString = "";
		public IConfigurationRoot Configuration { get; set; }
		public HabrDBContext CreateTestContext()
		{
			DirectoryInfo info = new DirectoryInfo(Directory.GetCurrentDirectory());
			DirectoryInfo temp = info.Parent.Parent.Parent.Parent;
			String CurDir = Path.Combine(temp.ToString(), "WebApp");
			String ConnStr = "Habr1_Test";
			Configuration = new ConfigurationBuilder().SetBasePath(CurDir).AddJsonFile("appsettings.json").Build();
			var builder = new DbContextOptionsBuilder<HabrDBContext>();
			var connectionString = Configuration.GetConnectionString(ConnStr);
			builder.UseSqlServer(connectionString);
			ConnectionString = connectionString;
			return this;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			String ConnStr = "";
			if (Configuration == null)
			{
#if DEBUG

				ConnStr = "Habr1_Local";
#else
				ConnStr= "Habr1_Production";
#endif

				Configuration = new ConfigurationBuilder()
				   .SetBasePath(Directory.GetCurrentDirectory())
				   .AddJsonFile("appsettings.json").Build();
				ConnectionString = Configuration.GetConnectionString(ConnStr);
			}

			optionsBuilder.UseSqlServer(ConnectionString);
		}
	}
}
