using Microsoft.EntityFrameworkCore;

namespace Command.Service.Infrastructure.Contexts;

public class CommandDbContext(DbContextOptions<CommandDbContext> options) : DbContext(options)
{
	public DbSet<Domain.Entities.Command>? Commands { get; set; }
	public DbSet<Domain.Entities.Platform>? Platforms { get; set; }
}