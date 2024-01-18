namespace Command.Service.Domain.DTOs;

public class ResponseCommand
{
	public int CommandId { get; set; }
	public required string HowTo { get; set; }
	public required string CommandLine { get; set; }
	public int PlatformId { get; set; }
}