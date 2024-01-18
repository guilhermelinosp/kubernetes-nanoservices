using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Platform.Service.Domain.Repositories;
using Platform.Service.Infrastructure.Contexts;
using Platform.Service.Infrastructure.Repositories;

namespace Platform.Service.Infrastructure;

public static class InfrastructureInjection
{
	public static void AddInfrastructureInjection(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext();
		services.AddRepositories();
	}

	private static void AddDbContext(this IServiceCollection services)
	{
		services.AddDbContext<PlatformDbContext>(options => { options.UseInMemoryDatabase("DB_Platform"); });
	}

	private static void AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<IPlatformRepository, PlatformRepository>();
	}
}