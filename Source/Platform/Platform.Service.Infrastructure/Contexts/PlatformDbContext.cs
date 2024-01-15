using Microsoft.EntityFrameworkCore;

namespace Platform.Service.Infrastructure.Contexts;

public class PlatformDbContext(DbContextOptions<PlatformDbContext> options) : DbContext(options)
{
	public DbSet<Domain.Entities.Platform>? Platforms { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlatformDbContext).Assembly);
		base.OnModelCreating(modelBuilder);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseInMemoryDatabase("DB_Platform");
		base.OnConfiguring(optionsBuilder);
	}
}