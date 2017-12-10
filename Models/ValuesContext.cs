using Microsoft.EntityFrameworkCore;

namespace OlentoWebApi.Models
{
	public class ValuesContext : DbContext
	{
		public ValuesContext(DbContextOptions<ValuesContext> options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var builder = new ConfigurationBuilder()
		 .AddJsonFile("../appsettings.json")
		 .AddEnvironmentVariables();
			var configuration = builder.Build();

			var sqlConnectionString = configuration["ConnectionStrings:OlentoServerConnection"];

			optionsBuilder.UseSqlite(sqlConnectionString);
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
