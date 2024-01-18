using Platform.Service.Domain.DTOs.Responses;

namespace Platform.Service.Domain.Synchronizations.Http;

public interface ICommandHttpClient
{
	Task SendPlatformToCommand(ResponsePlatform response);
}