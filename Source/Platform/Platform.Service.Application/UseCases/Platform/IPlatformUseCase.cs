using Platform.Service.Domain.DTOs.Requests;
using Platform.Service.Domain.DTOs.Responses;

namespace Platform.Service.Application.UseCases.Platforms;

public interface IPlatformUseCase
{
	Task<IEnumerable<ResponsePlatform>?> GetAllPlatforms();
	Task<ResponsePlatform?> GetPlatformById(Guid platformId);
	Task CreatePlatform(RequestPlatform platform);
}