using Command.Service.Domain.Repositories;
using Command.Service.Infrastructure.Contexts;
using Command.Service.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Command.Service.Infrastructure;

public static class InfrastructureInjection
{
	public static void AddInfrastructureInjection(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext();
		services.AddRepositories();
	}

	private static void AddDbContext(this IServiceCollection services)
	{
		services.AddDbContext<CommandDbContext>(options => { options.UseInMemoryDatabase("InMen"); });
	}

	private static void AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<ICommandRepository, CommandRepository>();
	}
}