using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Platform>? Platforms { get; set; }

		public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
		{
		}

	}
}
