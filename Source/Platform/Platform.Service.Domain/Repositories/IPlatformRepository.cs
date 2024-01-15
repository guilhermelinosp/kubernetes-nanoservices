namespace Platform.Service.Domain.Repositories;

public interface IPlatformRepository
{
	Task<IEnumerable<Entities.Platform?>> FindAllPlatforms();
	Task<Entities.Platform?> FindPlatformById(Guid platformId);
	Task CreatePlatform(Entities.Platform platform);
}