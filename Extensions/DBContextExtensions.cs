using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Extensions
{
	public static class DBContextExtensions
	{
		public static int EnsureDeleted<TEntity>(this DatabaseFacade db, DbSet<TEntity> set) where TEntity : class
		{
			TableDescription Table = GetTableName(set);
			int res = 0;
			try
			{
				res = db.ExecuteSqlRaw($"DROP TABLE [{Table.Schema}].[{Table.TableName}];");
			}
			catch (Exception)
			{

			}
			return res;
		}

		public static TableDescription GetTableName<T>(this DbSet<T> dbSet) where T : class
		{
			var dbContext = dbSet.GetDbContext();

			var model = dbContext.Model;
			var entityTypes = model.GetEntityTypes();
			var entityType = entityTypes.First(t => t.ClrType == typeof(T));
			var tableNameAnnotation = entityType.GetAnnotation("Relational:TableName");
			var tableSchemaAnnotation = entityType.GetAnnotation("Relational:Schema");
			var tableName = tableNameAnnotation.Value.ToString();
			var schemaName = tableSchemaAnnotation.Value.ToString();
			return new TableDescription { Schema = schemaName, TableName = tableName };
		}

		public static DbContext GetDbContext<T>(this DbSet<T> dbSet) where T : class
		{
			var infrastructure = dbSet as IInfrastructure<IServiceProvider>;
			var serviceProvider = infrastructure.Instance;
			var currentDbContext = serviceProvider.GetService(typeof(ICurrentDbContext)) as ICurrentDbContext;
			return currentDbContext.Context;
		}
	}

	public class TableDescription
	{
		public String Schema { get; set; }
		public String TableName { get; set; }
	}
}
