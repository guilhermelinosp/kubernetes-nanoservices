using Microsoft.EntityFrameworkCore;
using Platform.Service.Domain.Repositories;
using Platform.Service.Infrastructure.Contexts;

namespace Platform.Service.Infrastructure.Repositories;

public class PlatformRepository(PlatformDbContext context) : IPlatformRepository
{
	public async Task<IEnumerable<Domain.Entities.Platform?>> FindAllPlatforms()
	{
		return await context.Platforms.AsNoTracking().ToListAsync();
	}

	public async Task<Domain.Entities.Platform?> FindPlatformById(Guid platformId)
	{
		return await context.Platforms.FirstOrDefaultAsync(platform => platform!.PlatformId == platformId);
	}

	public async Task CreatePlatform(Domain.Entities.Platform? platform)
	{
		await context.Platforms.AddAsync(platform);

		await SaveChanges();
	}

	private async Task SaveChanges()
	{
		await context.SaveChangesAsync();
	}
}