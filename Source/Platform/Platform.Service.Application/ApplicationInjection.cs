using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Platform.Service.Application.Profiles;
using Platform.Service.Application.UseCases.Platforms;
using Platform.Service.Infrastructure;

namespace Platform.Service.Application;

public static class ApplicationInjection
{
	public static void AddApplicationInjection(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddInfrastructureInjection(configuration);
		services.AddUseCases();
		services.AddAutoMapper();
	}

	private static void AddUseCases(this IServiceCollection services)
	{
		services.AddScoped<IPlatformUseCase, PlatformUseCase>();
	}

	private static void AddAutoMapper(this IServiceCollection services)
	{
		services.AddAutoMapper(typeof(PlatformProfile));
	}
}