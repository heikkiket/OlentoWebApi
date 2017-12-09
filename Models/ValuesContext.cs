using Microsoft.EntityFrameworkCore;

namespace OlentoWebApi.Models
{
	public class ValuesContext : DbContext
	{
		public ValuesContext(DbContextOptions<ValuesContext> options)
			: base(options)
		{
		}

		public DbSet<ValuesItem> ValuesItems { get; set; }

		public static class ValuesContextFactory
		{
			public static ValuesContext Create(string connectionString)
			{
				var OptionsBuilder = new DbContextOptionsBuilder<ValuesContext>();
				OptionsBuilder.UseMySQL(connectionString);

				var context = new ValuesContext(OptionsBuilder.Options);
				context.Database.EnsureCreated();

				return context;
			}
		}

	}
}
