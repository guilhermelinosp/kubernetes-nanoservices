namespace Command.Service.Domain.DTOs;

public class RequestCommand
{
	public required string HowTo { get; set; }

	public required string CommandLine { get; set; }
}