using PlatformService.Dtos;

namespace PlatformService.AsyncDataService.Http
{
	public interface ICommandDataClient
	{
		Task SendPlatformToCommand(PlatformReadDto platform);
	}
}
