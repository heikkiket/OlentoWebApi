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

	}
}
