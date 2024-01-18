using Microsoft.EntityFrameworkCore;

namespace Command.Service.Infrastructure.Contexts.Persistences;

public static class PlatformDbContextFactory
{
	public static async Task<CommandDbContext> Create()
	{
		try
		{
			var optionsBuilder = new DbContextOptionsBuilder<CommandDbContext>();
			optionsBuilder.UseInMemoryDatabase("InMen");
			var commandDbContext = new CommandDbContext(optionsBuilder.Options);
			await commandDbContext.Database.EnsureCreatedAsync();
			return commandDbContext;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error creating database: {ex.Message}");
			throw;
		}
	}

	public static async Task<CommandDbContext> Destroy()
	{
		try
		{
			var optionsBuilder = new DbContextOptionsBuilder<CommandDbContext>();
			optionsBuilder.UseInMemoryDatabase("InMen");
			var commandDbContext = new CommandDbContext(optionsBuilder.Options);
			await commandDbContext.Database.EnsureDeletedAsync();
			return commandDbContext;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error deleting database: {ex.Message}");
			throw;
		}
	}
}