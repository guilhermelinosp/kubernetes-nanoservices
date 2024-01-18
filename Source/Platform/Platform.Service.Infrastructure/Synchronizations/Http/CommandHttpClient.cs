using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Platform.Service.Domain.DTOs.Responses;
using Platform.Service.Domain.Synchronizations.Http;

namespace Platform.Service.Infrastructure.Synchronizations.Http;

public class CommandHttpClient(HttpClient httpClient, IConfiguration configuration) : ICommandHttpClient
{
	public async Task SendPlatformToCommand(ResponsePlatform response)
	{
		var httpContent = new StringContent(
			JsonSerializer.Serialize(response),
			Encoding.UTF8,
			"application/json");

		var request = await httpClient.PostAsync($"{configuration["CommandService:Url"]}", httpContent);

		Console.WriteLine(request.IsSuccessStatusCode
			? "--> Sync POST to CommandService was OK!"
			: "--> Sync POST to CommandService was NOT OK!");
	}
}