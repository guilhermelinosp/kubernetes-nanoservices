using AutoMapper;
using Platform.Service.Domain.DTOs;
using Platform.Service.Domain.Repositories;

namespace Platform.Service.Application.UseCases.Platform;

public class PlatformUseCase(IPlatformRepository repository, IMapper mapper) : IPlatformUseCase
{
	public async Task<IEnumerable<ResponsePlatform>?> GetAllPlatforms()
	{
		return mapper.Map<IEnumerable<ResponsePlatform>>(await repository.FindAllPlatforms());
	}

	public async Task<ResponsePlatform?> GetPlatformById(Guid platformId)
	{
		return mapper.Map<ResponsePlatform>(await repository.FindPlatformById(platformId));
	}

	public async Task CreatePlatform(RequestPlatform platform)
	{
		await repository.CreatePlatform(mapper.Map<Domain.Entities.Platform>(platform));
	}
}