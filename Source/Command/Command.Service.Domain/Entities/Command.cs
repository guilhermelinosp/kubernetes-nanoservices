using System.ComponentModel.DataAnnotations;

namespace Command.Service.Domain.Entities;

public class Command
{
	[Key] public int CommandId { get; set; }

	public required string HowTo { get; set; }

	public required string CommandLine { get; set; }

	public int PlatformId { get; set; }

	public required Platform Platform { get; set; }
}