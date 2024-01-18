using Command.Service.Domain.Entities;

namespace Command.Service.Domain.Repositories;

public interface ICommandRepository
{
	Task<IEnumerable<Platform>> FindAllPlatforms();
}