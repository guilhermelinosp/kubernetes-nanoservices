using AutoMapper;
using Platform.Service.Domain.DTOs;
using Platform.Service.Domain.Repositories;

namespace Platform.Service.Application.UseCases.Platform;

public class PlatformUseCase(IPlatformRepository repository, IMapper mapper) : IPlatformUseCase
{
	public async Task<IEnumerable<PlatformRead>?> GetAllPlatforms()
	{
		return mapper.Map<IEnumerable<PlatformRead>>(await repository.FindAllPlatforms());
	}

	public async Task<PlatformRead?> GetPlatformById(Guid platformId)
	{
		return mapper.Map<PlatformRead>(await repository.FindPlatformById(platformId));
	}

	public async Task CreatePlatform(PlatformCreate platform)
	{
		await repository.CreatePlatform(mapper.Map<Domain.Entities.Platform>(platform));
	}
}