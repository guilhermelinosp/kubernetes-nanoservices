using Microsoft.EntityFrameworkCore;

namespace Platform.Service.Infrastructure.Contexts.Persistences;

public static class PlatformDbContextFactory
{
	public static async Task<PlatformDbContext> Create()
	{
		try
		{
			var optionsBuilder = new DbContextOptionsBuilder<PlatformDbContext>();
			optionsBuilder.UseInMemoryDatabase("DB_Platform");
			var platformDbContext = new PlatformDbContext(optionsBuilder.Options);
			await platformDbContext.Database.EnsureCreatedAsync();
			return platformDbContext;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error creating database: {ex.Message}");
			throw;
		}
	}

	public static async Task<PlatformDbContext> Destroy()
	{
		try
		{
			var optionsBuilder = new DbContextOptionsBuilder<PlatformDbContext>();
			optionsBuilder.UseInMemoryDatabase("DB_Platform");
			var platformDbContext = new PlatformDbContext(optionsBuilder.Options);
			await platformDbContext.Database.EnsureDeletedAsync();
			return platformDbContext;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error deleting database: {ex.Message}");
			throw;
		}
	}
}