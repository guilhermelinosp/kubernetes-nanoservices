using Platform.Service.Domain.DTOs;

namespace Platform.Service.Application.UseCases.Platform;

public interface IPlatformUseCase
{
	Task<IEnumerable<ResponsePlatform>?> GetAllPlatforms();
	Task<ResponsePlatform?> GetPlatformById(Guid platformId);
	Task CreatePlatform(RequestPlatform platform);
}