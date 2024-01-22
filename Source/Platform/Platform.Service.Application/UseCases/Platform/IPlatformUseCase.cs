using Platform.Service.Domain.DTOs;

namespace Platform.Service.Application.UseCases.Platform;

public interface IPlatformUseCase
{
	Task<IEnumerable<PlatformRead>?> GetAllPlatforms();
	Task<PlatformRead?> GetPlatformById(Guid platformId);
	Task CreatePlatform(PlatformCreate platform);
}