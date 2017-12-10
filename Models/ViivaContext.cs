using Microsoft.EntityFrameworkCore;

namespace OlentoWebApi.Models
{

	public class ViivaContext : DbContext
	{
		public ViivaContext(DbContextOptions<ViivaContext> options) : base(options)
		{
		}
		
		public DbSet<Viiva> viivat {get;set;}
		public DbSet<ValuesItem> ValuesItems {get;set;}
	}
}
