using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Platform.Service.Application.UseCases.Platform;
using Platform.Service.Domain.Profiles;
using Platform.Service.Infrastructure;

namespace Platform.Service.Application;

public static class ApplicationInjection
{
	public static void AddApplicationInjection(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddInfrastructureInjection(configuration);
		services.AddUseCases();
	}

	private static void AddUseCases(this IServiceCollection services)
	{
		services.AddScoped<IPlatformUseCase, PlatformUseCase>();
	}
}