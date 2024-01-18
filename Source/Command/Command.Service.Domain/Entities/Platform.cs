using System.ComponentModel.DataAnnotations;

namespace Command.Service.Domain.Entities;

public class Platform
{
	[Key] public int PlatformId { get; set; }

	public required int ExternalId { get; set; }

	public required string Name { get; set; }

	public ICollection<Command> Commands { get; set; } = new List<Command>();
}