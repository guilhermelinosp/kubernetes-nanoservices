using Command.Service.Domain.DTOs;

namespace Command.Service.Application.UseCases.Platform;

public interface IPlatformUseCase
{
	Task<IEnumerable<ResponsePlatform>?> GetAllPlatforms();
}