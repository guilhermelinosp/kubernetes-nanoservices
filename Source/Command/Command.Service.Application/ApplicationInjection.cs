using Command.Service.Application.UseCases.Command;
using Command.Service.Application.UseCases.Platform;
using Command.Service.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Command.Service.Application;

public static class ApplicationInjection
{
	public static void AddApplicationInjection(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddInfrastructureInjection(configuration);
		services.AddUseCases();
	}

	private static void AddUseCases(this IServiceCollection services)
	{
		services.AddScoped<ICommandUseCase, CommandUseCase>();
		services.AddScoped<IPlatformUseCase, PlatformUseCase>();
	}
}