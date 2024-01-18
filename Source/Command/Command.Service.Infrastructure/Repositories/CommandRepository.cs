using Command.Service.Domain.Repositories;
using Command.Service.Infrastructure.Contexts;

namespace Command.Service.Infrastructure.Repositories;

public class CommandRepository(CommandDbContext context) : ICommandRepository
{
	public async Task<IEnumerable<Domain.Entities.Platform>> FindAllPlatforms()
	{
		throw new NotImplementedException();
	}
}