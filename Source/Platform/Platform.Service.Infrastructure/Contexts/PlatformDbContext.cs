using Microsoft.EntityFrameworkCore;

namespace Platform.Service.Infrastructure.Contexts;

public class PlatformDbContext(DbContextOptions<PlatformDbContext> options) : DbContext(options)
{
	public DbSet<Domain.Entities.Platform>? Platforms { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlatformDbContext).Assembly);
	}
}