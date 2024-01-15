namespace Platform.Service.Infrastructure.Contexts.Persistences;

public static class PlatformDbContextExtensions
{
	public static async Task Seed(this PlatformDbContext platformDbContext)
	{
		if (platformDbContext.Platforms!.Any()) return;

		await platformDbContext.Platforms!.AddRangeAsync(new List<Domain.Entities.Platform>
		{
			new()
			{
				Name = "Another Platform 1",
				Publisher = "Another Publisher 1",
				Cost = "Free"
			},
			new()
			{
				Name = "Another Platform 2",
				Publisher = "Another Publisher 2",
				Cost = "Free"
			},
			new()
			{
				Name = "Another Platform 3",
				Publisher = "Another Publisher 3",
				Cost = "Free"
			},
			new()
			{
				Name = "Another Platform 4",
				Publisher = "Another Publisher 4",
				Cost = "Free"
			}
		});

		await platformDbContext.SaveChangesAsync();
	}
}