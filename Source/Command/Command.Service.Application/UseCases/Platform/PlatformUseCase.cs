using AutoMapper;
using Command.Service.Domain.DTOs;
using Command.Service.Domain.Repositories;

namespace Command.Service.Application.UseCases.Platform;

public class PlatformUseCase(ICommandRepository repository, IMapper mapper) : IPlatformUseCase
{
	public async Task<IEnumerable<ResponsePlatform>?> GetAllPlatforms()
	{
		return mapper.Map<IEnumerable<ResponsePlatform>>(await repository.FindAllPlatforms());
	}
}