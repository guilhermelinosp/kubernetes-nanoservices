using Platform.Service.Domain.DTOs;

namespace Platform.Service.Domain.Synchronizations.Http;

public interface ICommandHttpClient
{
	Task SendPlatformToCommand(PlatformRead response);
}